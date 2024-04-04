using Mazer.Core;
using Mazer.Core.MazeGenerators;
using System;

namespace Mazer.Presentation
{
    public class MazerPresenter
    {
        private readonly MazerModel _mazerModel;
        private readonly IMazerView _mazerView;

        public MazerPresenter(MazerModel mazerModel, IMazerView mazerView)
        {
            _mazerModel = mazerModel;
            _mazerView = mazerView;
            Init();
        }

        public void Run() 
        {
            _mazerView.Show();
        }

        private void Init() 
        {
            _mazerView.OnLoadForm += OnLoad;
            _mazerView.OnGenerateClick += OnGenerateClick;
            _mazerView.OnAnimateClick += OnAnimateClick;
            _mazerView.OnResizeForm += OnResizeForm;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            _mazerModel.InitMaze(_mazerView.MazeWidth, _mazerView.MazeHeight, _mazerView.RowsCount, _mazerView.ColumnsCount);
            _mazerView.InitMazeGenerators(_mazerModel.GetMazeGeenerators());
        }

        private void OnGenerateClick(object sender, EventArgs e)
        {
            MazeGeneratorBase mazeGenerator = _mazerView.GetSelectedMazeGenerator();
            ChangeMazeSize(mazeGenerator);
            mazeGenerator?.Refresh();
            mazeGenerator?.Generate();
            _mazerView.MazeDrawer.Draw(_mazerModel.Maze);
        }

        private void OnAnimateClick(object sender, EventArgs e)
        {
            MazeGeneratorBase mazeGenerator = _mazerView.GetSelectedMazeGenerator();
            ChangeMazeSize(mazeGenerator);
            mazeGenerator?.Refresh();
            _mazerView.MazeAnimator.Animate(_mazerModel.Maze, mazeGenerator);
        }

        private void ChangeMazeSize(MazeGeneratorBase mazeGenerator) 
        {
            _mazerModel.ChangeMazeSize(_mazerView.RowsCount, _mazerView.ColumnsCount);
        }

        private void OnResizeForm(object sender, EventArgs e)
        {
            _mazerModel.SetCellsSize(_mazerView.MazeWidth, _mazerView.MazeHeight);
            _mazerView.MazeDrawer.Draw(_mazerModel.Maze);
        }
    }
}