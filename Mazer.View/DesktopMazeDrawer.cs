using Mazer.Core.MazeModel;
using Mazer.Core.MazeVisualisation;
using System.Drawing;
using System.Windows.Forms;

namespace Mazer.View
{
    internal class DesktopMazeDrawer : MazeDrawerBase
    {
        private readonly PaintPanel _owner;
        private Maze _maze;

        public DesktopMazeDrawer(PaintPanel owner)
        {
            _owner = owner;
        }

        public override void Draw(Maze maze)
        {
            _maze = maze;
            Draw();
        }

        private void Draw()
        {
            _owner.PaintAction -= Draw;
            _owner.PaintAction += Draw;
            _owner.Refresh();
        }

        private void Draw(PaintEventArgs e)
        {
            foreach (MazeCell cell in _maze)
                DrawCell(cell, e.Graphics);
        }

        private void DrawCell(MazeCell cell, Graphics graphics)
        {
            if (cell.Current)
            {
                graphics.FillRectangle(Brushes.Purple, cell.X, cell.Y, cell.Size, cell.Size);
                cell.Current = false;
            }

            foreach (BorderType border in cell.Borders)
            {
                switch (border)
                {
                    case BorderType.Left:
                        graphics.DrawLine(Pens.White, cell.X, cell.Y, cell.X, cell.Y + cell.Size);
                        break;
                    case BorderType.Top:
                        graphics.DrawLine(Pens.White, cell.X, cell.Y, cell.X + cell.Size, cell.Y);
                        break;
                    case BorderType.Right:
                        graphics.DrawLine(Pens.White, cell.X + cell.Size, cell.Y, cell.X + cell.Size, cell.Y + cell.Size);
                        break;
                    case BorderType.Bottom:
                        graphics.DrawLine(Pens.White, cell.X, cell.Y + cell.Size, cell.X + cell.Size, cell.Y + cell.Size);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}