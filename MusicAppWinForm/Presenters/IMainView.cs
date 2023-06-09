
using PresentationLayer.DTO;

namespace PresentationLayer.Presenters
{
    public interface IMainView
    {
        void SetAlbumsBindingSource(BindingSource albums);
        void SetAlbumColumnNamesBindingSource(BindingSource albumColumns);

        event EventHandler GetAll;
        event Func<object, AlbumDTO, int> Add;
        event Func<object, AlbumDTO, int> UpdateAlbumEvent;
        event Action <object, string, string?> SearchInAlbums;
        event EventHandler GetColumnNamesFromAlbumTable;

        //--

        public string Album_Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string Image_URL { get; set; }
        public string Description { get; set; }
        public int ID { get; }

        public string Message { get; set; }
        public bool CRUD_IsSuccessful { get; set; }
    }
}
