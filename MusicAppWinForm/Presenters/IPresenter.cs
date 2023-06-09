using PresentationLayer.DTO;

namespace PresentationLayer.Presenters
{
    public interface IPresenter
    {
        int OnAdd(object? sender, AlbumDTO album);
        void OnGetAll(object? sender, EventArgs e);
        void OnSearchInAlbums(object? sender, string searchPhrase, string tableName);
    }
}
