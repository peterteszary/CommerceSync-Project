
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using ProductBridge.MVVM.Model;


namespace ProductBridge.Repositories
{
    public class UserRepository
    {
        private string connectionString;

        public UserRepository(string server, string database, string username, string password)
        {
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        public IEnumerable<User> GetAllUsersFromDatabase()
        {
            List<User> users = new List<User>();

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";

                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                UserName = reader["UserName"].ToString(),
                                UserEmail = reader["UserEmail"].ToString(),
                                UserPassword = reader["UserPassword"].ToString(),
                                UserRole = reader["UserRole"].ToString()
                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public void InsertUser(User user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (UserName, UserEmail, UserPassword, UserRole) VALUES (@UserName, @UserEmail, @UserPassword, @UserRole)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    command.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                    command.Parameters.AddWithValue("@UserRole", user.UserRole);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUserFromDatabase(int userId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE UserId = @UserId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(User user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Users SET UserName = @UserName, UserEmail = @UserEmail, UserPassword = @UserPassword, UserRole = @UserRole WHERE UserId = @UserId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    command.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                    command.Parameters.AddWithValue("@UserRole", user.UserRole);
                    command.Parameters.AddWithValue("@UserId", user.UserId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
    }
}

