using Mazer.Core.MazeModel;
using System;

namespace Mazer.Core.MazeGenerators
{
    public class MazeGeneratorBase
    {
        protected readonly Maze _maze;
        protected readonly Maze _initialMaze;

        public MazeGeneratorBase(Maze maze)
        {
            if (maze == null)
                throw new ArgumentNullException(nameof(maze));

            _maze = maze;
            _initialMaze = new Maze(maze.Width, maze.Height, maze.RowsCount, maze.ColumnsCount);
            _initialMaze.CopyCells(maze);
        }

        /// <summary>
        /// Do one step of <see cref="Maze"/> generation
        /// </summary>
        /// <returns><see cref="Maze"/></returns>
        public virtual Maze NextStep(bool useCurrent = true)
        {
            return _maze;
        }

        public virtual void Refresh() { }

        /// <summary>
        /// Generate <see cref="Maze"/>
        /// </summary>
        /// <returns><see cref="Maze"/></returns>
        public virtual Maze Generate()
        {
            return _maze;
        }
    }
}