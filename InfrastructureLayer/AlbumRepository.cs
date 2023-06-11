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

        public IEnumerable<Album> GetAll()
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

        public IEnumerable<Album> GetAlbumsByValue( string searchText, string columnName)
        {
            List<Album> foundAlbums = new();
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using var command = new SqlCommand
                    ($"SELECT * FROM Albums WHERE [{columnName}] LIKE @search", _connection);
                command.Parameters.AddWithValue("@search", "%" + searchText + "%").SqlDbType = SqlDbType.VarChar;
                GetResultingRecords(command, foundAlbums);
            }

            _connection.Close();
            return foundAlbums;
        }

        //--------------------------------------------------------------------------

        public int AddAlbum(Album album)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();

                //Does the record (by ID) already exist?
                using (var checkCommand = new SqlCommand
                    ("IF EXISTS(SELECT 1 FROM Albums WHERE ID = @ID) SELECT 1 ELSE SELECT 0", _connection))
                {
                    checkCommand.Parameters.Add("@ID", SqlDbType.Int).Value = album.ID;
                    bool recordExists = (int)checkCommand.ExecuteScalar() == 1;

                    // If the record already exists, return 0 to indicate no rows affected
                    if (recordExists)
                    {
                        _connection.Close();
                        return 0;
                    }
                }

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

        //--------------------------------------------------------------------------

        public int Edit(Album album)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using var command = new SqlCommand(
                    @"UPDATE Albums SET [Album Title] = @Album_Title, Artist = @Artist, Year = @Year, [Image URL] = @Image_URL, Description = @Description WHERE ID = @ID", _connection);
                command.Parameters.Add("@ID", SqlDbType.Int).Value = album.ID;
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

        //--------------------------------------------------------------------------

        public List<string> GetTableColumns(string tableName)
        {
            List<string> columnNames = new List<string>();
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                string query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";
                using var command = new SqlCommand(query, _connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader.GetString(0);
                    columnNames.Add(columnName);
                }
            }

            return columnNames;
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
