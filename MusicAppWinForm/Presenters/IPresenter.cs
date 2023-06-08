using PresentationLayer.DTO;

namespace PresentationLayer.Presenters
{
    public interface IPresenter
    {
        int AddNew(object? sender, AlbumDTO album);
        void GetAll(object? sender, EventArgs e);
        void SearchInAlbums(object? sender, string phraseToLookFor);
        void SetBindingSource();
    }
}
