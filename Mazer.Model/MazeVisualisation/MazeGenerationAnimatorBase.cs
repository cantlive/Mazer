using Mazer.Core.MazeGenerators;
using Mazer.Core.MazeModel;

namespace Mazer.Core.MazeVisualisation
{
    public abstract class MazeGenerationAnimatorBase
    {
        protected readonly MazeDrawerBase _drawer;
        protected readonly int _speed;

        public MazeGenerationAnimatorBase(MazeDrawerBase drawer, int speed)
        {
            _drawer = drawer;
            _speed = speed;
        }

        public abstract void Animate(Maze maze, MazeGeneratorBase mazeGenerator);

        public abstract void StopAnimate();
    }
}