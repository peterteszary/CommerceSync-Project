using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ProductBridge.DataAccess
{
    public class DataAccess
    {
        private string connectionString;

        public DataAccess(string server, string database, string username, string password)
        {
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }





        public void InsertWoosyncAuth(string apiKey, string websiteUrl)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                // Previous data deletion
                string deleteQuery = "DELETE FROM woosync_auth";
                using (var deleteCommand = new MySqlCommand(deleteQuery, connection))
                {
                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                }

                // Insert new data
                string insertQuery = "INSERT INTO woosync_auth (woosync_api_key, remote_url) VALUES (@ApiKey, @WebsiteUrl)";
                using (var insertCommand = new MySqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@ApiKey", apiKey);
                    insertCommand.Parameters.AddWithValue("@WebsiteUrl", websiteUrl);

                    insertCommand.ExecuteNonQuery();
                }
            }
        }

        public void ResetData()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string dropProductsTableQuery = "DROP TABLE IF EXISTS Products";
                string dropUsersTableQuery = "DROP TABLE IF EXISTS Users";
                string dropWoosyncAuthTableQuery = "DROP TABLE IF EXISTS woosync_auth";

                using (var dropProductsTableCommand = new MySqlCommand(dropProductsTableQuery, connection))
                using (var dropUsersTableCommand = new MySqlCommand(dropUsersTableQuery, connection))
                using (var dropWoosyncAuthTableCommand = new MySqlCommand(dropWoosyncAuthTableQuery, connection))
                {
                    connection.Open();
                    dropProductsTableCommand.ExecuteNonQuery();
                    dropUsersTableCommand.ExecuteNonQuery();
                    dropWoosyncAuthTableCommand.ExecuteNonQuery();
                }
            }
        }

        public (string apiKey, string websiteUrl) GetWoosyncAuth()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT woosync_api_key, remote_url FROM woosync_auth";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string apiKey = reader.GetString(0);
                            string websiteUrl = reader.GetString(1);
                            return (apiKey, websiteUrl);
                        }
                        else
                        {

                            return (string.Empty, string.Empty);
                        }
                    }
                }
            }
        }
    }
}
