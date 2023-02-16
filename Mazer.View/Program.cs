using Mazer.Core;
using Mazer.Presentation;
using System;
using System.Windows.Forms;

namespace Mazer.View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var presenter = new MazerPresenter(new MazerModel(), new MazerForm());
            presenter.Run();
        }
    }
}