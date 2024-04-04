using Mazer.Core.MazeGenerators;
using Mazer.Core.MazeVisualisation;
using Mazer.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mazer.View
{
    public partial class MazerForm : Form, IMazerView
    {
        private readonly DesktopMazeDrawer _mazeDrawer;
        private readonly DesktopMazeAnimator _mazeAnimator;
        private bool _sizing = false;

        public MazerForm()
        {
            InitializeComponent();
            _mazeDrawer = new DesktopMazeDrawer(paintPanel_Maze);
            _mazeAnimator = new DesktopMazeAnimator(_mazeDrawer, (int)numericUpDown_AnimationSpeed.Value);
        }

        public new void Show() 
        {
            Application.Run(this);
        }

        public int MazeWidth => paintPanel_Maze.Width;

        public int MazeHeight => paintPanel_Maze.Height;

        public int RowsCount => (int)numericUpDown_RowsCount.Value;

        public int ColumnsCount => (int)numericUpDown_ColumnsCount.Value;

        public MazeDrawerBase MazeDrawer => _mazeDrawer;

        public MazeGenerationAnimatorBase MazeAnimator => _mazeAnimator;

        public event EventHandler OnGenerateClick;
        public event EventHandler OnAnimateClick;
        public event EventHandler OnLoadForm;
        public event EventHandler OnResizeForm;

        public MazeGeneratorBase GetSelectedMazeGenerator()
        {
            return comboBox_MazeGenerators.SelectedItem as MazeGeneratorBase;
        }

        public void InitMazeGenerators(IEnumerable<MazeGeneratorBase> mazeGenerators)
        {
            comboBox_MazeGenerators.Items.AddRange(mazeGenerators.ToArray());
            comboBox_MazeGenerators.SelectedIndex = 0;
        }

        private void MazerForm_Load(object sender, EventArgs e)
        {
            OnLoadForm(sender, e);
        }

        private void button_Generate_Click(object sender, EventArgs e)
        {
            OnGenerateClick(sender, e);
        }

        private void button_Animate_Click(object sender, EventArgs e)
        {
            OnAnimateClick(sender, e);
        }

        private void MazerForm_Resize(object sender, EventArgs e)
        {
            _sizing = true;
            if (WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Minimized)
                MazerForm_ResizeEnd(sender, e);
        }

        private void MazerForm_ResizeEnd(object sender, EventArgs e)
        {
            if (!_sizing) 
                return;

            if (_sizing) 
            { 
                _sizing = false;
                OnResizeForm(sender, e);
            }
        }
    }
}