using System;
using System.Windows;
using MySql.Data.MySqlClient;

namespace ProductBridge
{
    public partial class App : Application
    {
        public static string FolderPath { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DatabaseName { get; } = "Products.db";
        public static string DatabasePath { get; } = System.IO.Path.Combine(FolderPath, DatabaseName);
        public static string UsersTableName { get; } = "Users";

        // Új adatbázis-műveletekhez szükséges adatok
        public static string Server { get; } = "localhost";
        public static string Database { get; } = "productbridge";
        public static string Username { get; } = "root";
        public static string Password { get; } = "";

        // Az alkalmazás indulásakor inicializáljuk az adatbázist
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Adatbázis inicializálása
            InitializeDatabase();
        }

        // Adatbázis inicializálása
        private void InitializeDatabase()
        {
            string connectionString = $"Server={Server};Uid={Username};Pwd={Password};";

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Adatbázis létrehozása
                    string createDatabaseQuery = $"CREATE DATABASE IF NOT EXISTS {Database}";
                    using (var createDatabaseCommand = new MySqlCommand(createDatabaseQuery, connection))
                    {
                        createDatabaseCommand.ExecuteNonQuery();
                    }

                    // Kapcsolat újra létrehozása a létrehozott adatbázissal
                    connection.ChangeDatabase(Database);

                    // Táblák létrehozása
                    string createProductsTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Products (
                            ProductId INT AUTO_INCREMENT PRIMARY KEY,
                            ProductName VARCHAR(255),
                            Price DECIMAL(10,2),
                            SalesPrice DECIMAL(10,2),
                            Category VARCHAR(255),
                            StockQuantity INT,
                            SKU VARCHAR(255),
                            Tags VARCHAR(255) DEFAULT '',  -- Engedélyezzük a null értékeket
                            ShortDescription TEXT,
                            LongDescription TEXT,
                            ImageUrl VARCHAR(255) DEFAULT '',  -- Engedélyezzük a null értékeket
                            GalleryUrls TEXT DEFAULT ''  -- Engedélyezzük a null értékeket
                        )";

                    using (var createProductsTableCommand = new MySqlCommand(createProductsTableQuery, connection))
                    {
                        createProductsTableCommand.ExecuteNonQuery();
                    }

                    string createUsersTableQuery = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserId INT AUTO_INCREMENT PRIMARY KEY,
                    UserName VARCHAR(255),
                    UserEmail VARCHAR(255),
                    UserPassword VARCHAR(255),
                    UserRole VARCHAR(255)
                )";
                    using (var createUsersTableCommand = new MySqlCommand(createUsersTableQuery, connection))
                    {
                        createUsersTableCommand.ExecuteNonQuery();
                    }

                    // Tábla létrehozása az API kulcsok és URL-ek tárolásához
                    string createWoosyncAuthTableQuery = @"
                CREATE TABLE IF NOT EXISTS woosync_auth (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    woosync_api_key VARCHAR(255),
                    remote_url VARCHAR(255)
                )";
                    using (var createWoosyncAuthTableCommand = new MySqlCommand(createWoosyncAuthTableQuery, connection))
                    {
                        createWoosyncAuthTableCommand.ExecuteNonQuery();
                    }

                    Console.WriteLine("Az adatbázis és a táblák sikeresen létrehozva.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hiba történt az adatbázis és a táblák létrehozása során: {ex.Message}");
                }
            }
        }

        // Adatok törlése az adatbázisból
        public void ResetData()
        {
            string connectionString = $"Server={Server};Uid={Username};Pwd={Password};Database={Database}";

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Táblák törlése
                    string dropProductsTableQuery = "DROP TABLE IF EXISTS Products";
                    using (var dropProductsTableCommand = new MySqlCommand(dropProductsTableQuery, connection))
                    {
                        dropProductsTableCommand.ExecuteNonQuery();
                    }

                    string dropUsersTableQuery = "DROP TABLE IF EXISTS Users";
                    using (var dropUsersTableCommand = new MySqlCommand(dropUsersTableQuery, connection))
                    {
                        dropUsersTableCommand.ExecuteNonQuery();
                    }

                    string dropWoosyncAuthTableQuery = "DROP TABLE IF EXISTS woosync_auth";
                    using (var dropWoosyncAuthTableCommand = new MySqlCommand(dropWoosyncAuthTableQuery, connection))
                    {
                        dropWoosyncAuthTableCommand.ExecuteNonQuery();
                    }

                    Console.WriteLine("Az adatbázis táblák sikeresen törölve.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hiba történt az adatbázis táblák törlése során: {ex.Message}");
                }
            }
        }

    }
}

