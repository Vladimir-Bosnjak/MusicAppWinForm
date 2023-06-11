using Models;

namespace ServiceLayer
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAll();
        IEnumerable<Album> GetAlbumsByValue(string search, string columnName);
        int AddAlbum(Album album);
        int Edit(Album theAlbum);
        List<string> GetTableColumns(string tableName);
    }
}
