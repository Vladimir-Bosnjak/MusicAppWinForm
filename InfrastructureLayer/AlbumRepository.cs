using Models;
using System.Data.SqlClient;
using ServiceLayer;
using System.Data;
using InfrastructureLayer;

namespace PresentationLayer
{
    public class AlbumRepository : BaseRepository, IAlbumRepository
    {
        private SqlConnection? _connection;

        //--------------------------------------------------------------------------

        // _connectionString is inherited from BaseRepository but initialized here
        // because of dependency injections purposes and is easier in unit-testing.
        public AlbumRepository(string connectionString) =>
            _connectionString = connectionString;

        //--------------------------------------------------------------------------

        public IEnumerable<IAlbum> GetAll()
        {
            List<Album> allAlbums = new();

            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using var command = new SqlCommand(@"SELECT * FROM Albums", _connection);
                GetResultingRecords(command, allAlbums); 
            }

            _connection.Close();
            return allAlbums;
        }

        //--------------------------------------------------------------------------

        public IEnumerable<IAlbum> GetAlbumsByValue(string searchText)
        {
            List<Album> foundAlbums = new();
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using var command = new SqlCommand(@"SELECT * FROM Albums WHERE [Album Title] LIKE @search", _connection);
                command.Parameters.AddWithValue("@search", "%" + searchText + "%").SqlDbType = SqlDbType.VarChar;
                GetResultingRecords(command, foundAlbums); 
            }

            _connection.Close();
            return foundAlbums;
        }

        //--------------------------------------------------------------------------

        public int AddAlbum(IAlbum album)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using var command = new SqlCommand(
                    @"INSERT into Albums values (@Album_Title, @Artist, @Year, @Image_URL, @Description)", _connection);
                command.Parameters.Add("@Album_Title", SqlDbType.VarChar).Value = album.Album_Title;
                command.Parameters.Add("@Artist", SqlDbType.VarChar).Value = album.Artist;
                command.Parameters.Add("@Year", SqlDbType.Int).Value = album.Year;
                command.Parameters.Add("@Image_URL", SqlDbType.VarChar).Value = album.Image_URL;
                command.Parameters.Add("@Description", SqlDbType.VarChar).Value = album.Description;

                int rowsAffected = command.ExecuteNonQuery();
                _connection.Close();
                return rowsAffected;
            }
        }

        //------------------------- privates below ---------------------------------


        private static void GetResultingRecords(SqlCommand cmd, List<Album> albums)
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var album = new Album();
                    album.ID = reader.GetInt32(0);
                    album.Album_Title = reader.GetString(1);
                    album.Artist = reader.GetString(2);
                    album.Year = reader.GetInt32(3);
                    album.Image_URL = reader.GetString(4);
                    album.Description = reader.GetString(5);

                    albums.Add(album);
                }
            }
        }


    }
}
