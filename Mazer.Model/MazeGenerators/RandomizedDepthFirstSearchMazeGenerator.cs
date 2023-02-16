using Mazer.Core.MazeModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mazer.Core.MazeGenerators
{
    public sealed class RandomizedDepthFirstSearchMazeGenerator : MazeGeneratorBase
    {
        private Random _random = new Random();
        private readonly Stack<MazeCell> _cellsStack = new Stack<MazeCell>();
        private readonly HashSet<MazeCell> _visitedCells = new HashSet<MazeCell>();

        public RandomizedDepthFirstSearchMazeGenerator(Maze maze) : base(maze)
        {
            if (maze.ColumnsCount != 0 && maze.RowsCount != 0)
                _cellsStack.Push(maze[0, 0]);
        }

        public override void Refresh()
        {
            _random = new Random();
            _maze.CopyCells(_initialMaze);

            _visitedCells.Clear();
            _cellsStack.Clear();
            if (_maze.ColumnsCount != 0 && _maze.RowsCount != 0)
                _cellsStack.Push(_maze[0, 0]);
        }

        public override Maze Generate()
        {
            while (_cellsStack.Count > 0)
                NextStep(useCurrent: false);

            return base.Generate();
        }

        public override Maze NextStep(bool useCurrent = true)
        {
            if (_cellsStack.Count == 0)
                return base.NextStep();

            MazeCell current = _cellsStack.Pop();
            if (useCurrent)
                current.Current = true;

            List<MazeCell> neighbours = _maze.GetCellNeighbours(current)
                .Where(x => _visitedCells.Contains(x) == false)
                .ToList();

            if (neighbours.Count > 0)
            {
                int index = _random.Next(0, neighbours.Count);
                MazeCell neighbor = neighbours[index];
                _cellsStack.Push(current);
                _maze.RemoveBordersBetweenNeighbours(current, neighbor);
                _visitedCells.Add(neighbor);
                _cellsStack.Push(neighbor);
            }

            return base.NextStep();
        }

        public override string ToString()
        {
            return "Randomized depth-first search";
        }
    }
}