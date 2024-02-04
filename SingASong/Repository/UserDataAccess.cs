using SingASong.Models;
using System.Data;
using System.Data.SqlClient;


namespace SingASong.Repository
{
    public class UserDataAccess
    {
        private readonly string connectionString;

        public UserDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void RegisterUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("RegisterUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    command.Parameters.AddWithValue("@UserName", user.userName);
                    command.Parameters.AddWithValue("@UserPassword", user.userPassword);
                    command.Parameters.AddWithValue("@UserEmail", user.userEmail);
                    command.Parameters.AddWithValue("@UserPhoneNo", user.userPhoneNo);
                    command.Parameters.AddWithValue("@UserAddress", user.userAddress);


                    command.ExecuteNonQuery();
                }
            }
        }

        public User ValidateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ValidateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserEmail", user.userEmail);
                    command.Parameters.AddWithValue("@UserPassword", user.userPassword);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                userID = Convert.ToInt32(reader["UserID"]),
                                userName = reader["UserName"].ToString(),
                                userEmail = reader["UserEmail"].ToString(),
                                userPhoneNo = reader["UserPhoneNo"].ToString(),
                                userAddress = reader["UserAddress"].ToString()

                            };
                        }
                    }
                }
            }

            return null; // User not found or invalid credentials
        }



        public bool CheckAdminPrivileges(int userID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT IsAdmin FROM Users WHERE UserID = @UserID", connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    var result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return (bool)result;
                    }
                }
            }

            return false; // Default to false if no result or conversion fails
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

        public Cart GetCartAlbums(int userID)
        {
            decimal totalAmount = 0;
            List<Album> cartSongs = new List<Album>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetCartAlbums", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Check for NULLs before accessing values
                            int albumID = reader.IsDBNull(reader.GetOrdinal("AlbumID")) ? 0 : Convert.ToInt32(reader["AlbumID"]);
                            string albumName = reader.IsDBNull(reader.GetOrdinal("AlbumName")) ? string.Empty : reader["AlbumName"].ToString();
                            string artistName = reader.IsDBNull(reader.GetOrdinal("ArtistName")) ? string.Empty : reader["ArtistName"].ToString();
                            decimal albumPrice = reader.IsDBNull(reader.GetOrdinal("AlbumPrice")) ? 0 : Convert.ToDecimal(reader["AlbumPrice"]);

                            Album music = new Album
                            {
                                albumID = albumID,
                                albumName = albumName,
                                artistName = artistName,
                                albumPrice = albumPrice
                                // Add other properties as needed
                            };

                            cartSongs.Add(music);
                            totalAmount += music.albumPrice;
                        }
                    }
                }
            }

            Cart cart = new Cart
            {
                cartAlbum = cartSongs,
                price = totalAmount
            };

            return cart;
        }


        public void DeleteFromCart(int albumID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DeleteFromCart", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AlbumID", albumID);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
