using Mazer.Core.MazeGenerators;
using Mazer.Core.MazeModel;
using Mazer.Core.MazeVisualisation;
using System;
using System.Windows.Forms;

namespace Mazer.View
{
    internal sealed class DesktopMazeAnimator : MazeGenerationAnimatorBase, IDisposable
    {
        private readonly Timer _timer;
        public DesktopMazeAnimator(MazeDrawerBase drawer, int speed) : base(drawer, speed)
        {
            _timer = new Timer();
            _timer.Interval = Math.Max(1, 1000 / speed);
        }

        public override void Animate(Maze maze, MazeGeneratorBase mazeGenerator)
        {
            _timer.Tick += (o, e) =>
            {
                mazeGenerator.NextStep();
                _drawer.Draw(maze);
            };
            _timer.Start();
        }

        public override void StopAnimate()
        {
            _timer.Stop();
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}