using SingASong.Models;
using System.Data;
using System.Data.SqlClient;

namespace SingASong.Repository
{
    public class DBAccess
    {
        private readonly string connectionString;

        public DBAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Album> GetAllAlbums()
        {
            List<Album> musicList = new List<Album>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAllAlbums", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Album music = new Album
                            {
                                albumID = Convert.ToInt32(reader["AlbumID"]),
                                albumName = reader["AlbumName"].ToString(),
                                artistName = reader["ArtistName"].ToString(),
                                albumPrice = Convert.ToDecimal(reader["AlbumPrice"]),
                                albumRating = Convert.ToDecimal(reader["AlbumRating"]),
                                albumGenre = reader["AlbumGenre"].ToString()
                            };

                            musicList.Add(music);
                        }
                    }
                }
            }

            return musicList;

        }

        public void AddAlbum(Album music)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("AddAlbum", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AlbumName", music.albumName);
                    command.Parameters.AddWithValue("@ArtistName", music.artistName);
                    command.Parameters.AddWithValue("@AlbumPrice", music.albumPrice);
                    command.Parameters.AddWithValue("@AlbumRating", music.albumRating);
                    //command.Parameters.AddWithValue("@AlbumDate", music.AlbumDate);
                    command.Parameters.AddWithValue("@AlbumGenre", music.albumGenre);


                    command.ExecuteNonQuery();
                }
            }
        }


        public Album GetAlbumById(int? searchedAlbumId)
        {

            Album searchAlbum = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetAlbumById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AlbumID", searchedAlbumId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            searchAlbum = new Album
                            {
                                albumID = Convert.ToInt32(reader["AlbumID"]),
                                albumName = reader["AlbumName"].ToString(),
                                artistName = reader["ArtistName"].ToString(),
                                albumPrice = Convert.ToDecimal(reader["AlbumPrice"]),
                                albumRating = Convert.ToDecimal(reader["AlbumRating"]),
                                albumGenre = reader["AlbumGenre"].ToString()
                            };
                        }
                    }
                }
            }
            return searchAlbum;
        }



        public Album GetAlbumByName(string searchedAlbumName)
        {

            Album searchAlbum = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetAlbumByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AlbumName", searchedAlbumName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            searchAlbum = new Album
                            {
                                albumID = Convert.ToInt32(reader["AlbumID"]),
                                albumName = reader["AlbumName"].ToString(),
                                artistName = reader["ArtistName"].ToString(),
                                albumPrice = Convert.ToDecimal(reader["AlbumPrice"]),
                                albumRating = Convert.ToDecimal(reader["AlbumRating"]),
                                albumGenre = reader["AlbumGenre"].ToString()
                            };
                        }
                    }
                }
            }
            return searchAlbum;
        }



        public void UpdateAlbum(Album updatedAlbum)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpdateAlbum", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@AlbumID", updatedAlbum.albumID);
                    command.Parameters.AddWithValue("@AlbumName", updatedAlbum.albumName);
                    command.Parameters.AddWithValue("@ArtistName", updatedAlbum.artistName);
                    command.Parameters.AddWithValue("@AlbumPrice", updatedAlbum.albumPrice);
                    command.Parameters.AddWithValue("@AlbumRating", updatedAlbum.albumRating);
                    command.Parameters.AddWithValue("@AlbumGenre", updatedAlbum.albumGenre);


                    // ExecuteNonQuery for UPDATE operations
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAlbum(int albumID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteAlbum", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameter
                        command.Parameters.AddWithValue("@AlbumID", albumID);

                        // ExecuteNonQuery for DELETE operations
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error deleting album: {ex.Message}");
                throw; // Rethrow the exception or handle appropriately
            }
        }


        public void AddToCart(int userID, int albumID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("AddToCart", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@AlbumID", albumID);
                    command.Parameters.AddWithValue("@Quantity", 1);


                    // Add other parameters as needed

                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
