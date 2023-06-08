
using PresentationLayer.Views.EventArguments;

namespace PresentationLayer.Presenters
{
    public interface IMainView
    {
        void SetAlbumsBindingSource(BindingSource albums);
        event EventHandler GetAll;
        event Func<object, AddOrEditEventArgs, int> Add;
        event EventHandler<string> SearchInAlbums;

        //--

        public string Album_Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string Image_URL { get; set; }
        public string Description { get; set; }

        public string Message { get; set; }
        public bool CRUD_IsSuccessful { get; set; }
    }
}
