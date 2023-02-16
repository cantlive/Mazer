using Mazer.Core.MazeGenerators;
using Mazer.Core.MazeModel;
using Mazer.Core.Utils;
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
    }
}