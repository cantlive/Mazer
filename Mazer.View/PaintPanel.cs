using System.Windows.Forms;

namespace Mazer.View
{
    public sealed class PaintPanel : Panel
    {
        public delegate void PaintHandler(PaintEventArgs e);
        public event PaintHandler PaintAction;

        public PaintPanel()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintAction?.Invoke(e);
            base.OnPaint(e);
        }
    }
}