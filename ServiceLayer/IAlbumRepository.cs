using Models;

namespace ServiceLayer
{
    public interface IAlbumRepository
    {
        IEnumerable<IAlbum> GetAll();
        IEnumerable<IAlbum> GetAlbumsByValue(string SearchByAlbum);
        int AddAlbum(IAlbum album);
    }
}
