using Models;

namespace ServiceLayer
{
    public interface IAlbumRepository
    {
        IEnumerable<IAlbum> GetAll();
        IEnumerable<IAlbum> GetAlbumsByValue(string search, string columnName);
        int AddAlbum(IAlbum album);
        int Edit(Album theAlbum);
        List<string> GetTableColumns(string tableName);
    }
}
