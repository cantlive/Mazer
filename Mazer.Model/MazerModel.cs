using Mazer.Core.MazeGenerators;
using Mazer.Core.MazeModel;
using Mazer.Core.Utils;
using System;
using System.Collections.Generic;

namespace Mazer.Core
{
    public class MazerModel
    {
        private Maze _maze;

        public Maze Maze => _maze;

        public void InitMaze(int width, int height, int rowsCount, int columnsCount)
        {
            _maze = new Maze(width, height, rowsCount, columnsCount);
        }

        public IEnumerable<MazeGeneratorBase> GetMazeGeenerators() 
        {
            return ReflectiveEnumerator.GetEnumerableOfType<MazeGeneratorBase>(_maze);
        }

        public void ChangeMazeSize(int rowsCount, int columnsCount)
        {
            _maze.SetMazeSize(rowsCount, columnsCount);
        }

        public void ChangeMazeSize(Maze maze, int rowsCount, int columnsCount)
        {
            maze.SetMazeSize(rowsCount, columnsCount);
        }

        public void SetCellsSize(int width, int height) 
        {
            _maze.SetCellsSize(width, height);
        }
    }
}