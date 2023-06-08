using PresentationLayer.Presenters;
using ServiceLayer;

namespace PresentationLayer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //--------------------------------------------

            string connectionString = "Data Source=.;Initial Catalog=Music;Integrated Security=True";
            IAlbumRepository albumRepository = new AlbumRepository(connectionString);
            IMainView mainView = new MusicForm();
            new Presenter(mainView, albumRepository);

            //--------------------------------------------
            Application.Run((Form)(mainView));
        }
    }
}