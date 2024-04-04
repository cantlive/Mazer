using Mazer.Core.MazeModel;
using System;
using System.Collections.Generic;
using static Mazer.Core.MazeModel.Maze;

namespace Mazer.Core.MazeGenerators
{
    public sealed class RandomizedPrimsGenerator : MazeGeneratorBase
    {
        private readonly List<MazeCell> _frontierCells = new List<MazeCell>();
        private readonly List<MazeCell> _visitedCells = new List<MazeCell>();
        private Random _random = new Random();
        
        public RandomizedPrimsGenerator(Maze maze) : base(maze)
        {
            Init();
        }

        public override void Refresh()
        {
            _random = new Random();
            _maze.Reset();
            _visitedCells.Clear();
            _frontierCells.Clear();
            Init();
        }

        public override Maze Generate()
        {
            while (_frontierCells.Count > 0)
                NextStep(useCurrent: false);

            return base.Generate();
        }

        public override Maze NextStep(bool useCurrent = true)
        {
            int randomIndex = _random.Next(_frontierCells.Count);
            MazeCell currentCell = _frontierCells[randomIndex];
            currentCell.Current = true;

            List<MazeCell> neighbors = _maze.GetCellNeighbours(currentCell);

            if (neighbors.Count > 0)
            {
                int neighborIndex = _random.Next(neighbors.Count);
                MazeCell neighborCell = neighbors[neighborIndex];

                _maze.RemoveBordersBetweenNeighbours(currentCell, neighborCell);
                currentCell.Visited = true;
                _visitedCells.Add(currentCell);

                AddFrontierCells(currentCell);
                AddFrontierCells(neighborCell);
            }

            _frontierCells.Remove(currentCell);

            return base.NextStep();
        }

        private void Init()
        {
            int startX = _random.Next(_maze.ColumnsCount);
            int startY = _random.Next(_maze.RowsCount);

            MazeCell currentCell = _maze[startX, startY];
            _visitedCells.Add(currentCell);

            currentCell.RemoveBorders(BorderType.Bottom);
            currentCell.Visited = true;
            AddFrontierCells(currentCell);
        }

        private void AddFrontierCells(MazeCell cell)
        {
            MazeCellIndex index = _maze.GetCellIndex(cell);

            if (index.X > 0 && !_frontierCells.Contains(_maze[index.X - 1, index.Y]) && !cell.Left && !_maze[index.X - 1, index.Y].Visited)
                _frontierCells.Add(_maze[index.X - 1, index.Y]);
            if (index.X < _maze.ColumnsCount - 1 && !_frontierCells.Contains(_maze[index.X + 1, index.Y]) && !cell.Right && !_maze[index.X + 1, index.Y].Visited)
                _frontierCells.Add(_maze[index.X + 1, index.Y]);
            if (index.Y > 0 && !_frontierCells.Contains(_maze[index.X, index.Y - 1]) && !cell.Top && !_maze[index.X, index.Y - 1].Visited)
                _frontierCells.Add(_maze[index.X, index.Y - 1]);
            if (index.Y < _maze.RowsCount - 1 && !_frontierCells.Contains(_maze[index.X, index.Y + 1]) && !cell.Bottom && !_maze[index.X, index.Y + 1].Visited)
                _frontierCells.Add(_maze[index.X, index.Y + 1]);
        }

        public override string ToString()
        {
            return "Randomized Prim's";
        }
    }
}
