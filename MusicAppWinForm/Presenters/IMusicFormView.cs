using PresentationLayer.EventArguments;

namespace PresentationLayer.Presenters
{
    public interface IMusicFormView
    {
        void SetAlbumsBindingSource(BindingSource albums);
        void SetAlbumColumnNamesBindingSource(BindingSource albumColumns);

        event EventHandler GetAll;
        public event EventHandler<AlbumDataEventArgs>? AddEvent;
        event EventHandler<AlbumDataEventArgs> UpdateAlbumEvent;
        public event EventHandler<SearchEventArgs>? SearchInAlbums;
        event EventHandler GetColumnNamesFromAlbumTableEvent;

        //--

        public string Album_Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string Image_URL { get; set; }
        public string Description { get; set; }
        public int ID { get; }

        public string Message { get; set; }
        public bool CRUD_IsSuccessful { get; set; }
        public int RowsAffected { get; set; }
    }
}
