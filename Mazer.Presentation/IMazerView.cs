using Mazer.Core.MazeGenerators;
using Mazer.Core.MazeVisualisation;
using System;
using System.Collections.Generic;

namespace Mazer.Presentation
{
    public interface IMazerView
    {
        void Show();
        void InitMazeGenerators(IEnumerable<MazeGeneratorBase> mazeGenerators);
        MazeGeneratorBase GetSelectedMazeGenerator();
        int MazeWidth { get; }
        int MazeHeight { get; }
        int RowsCount { get; }
        int ColumnsCount { get; }
        MazeDrawerBase MazeDrawer { get; }
        MazeGenerationAnimatorBase MazeAnimator { get; }

        event EventHandler OnResizeForm;

        event EventHandler OnLoadForm;

        event EventHandler OnGenerateClick;

        event EventHandler OnAnimateClick;
    }
}