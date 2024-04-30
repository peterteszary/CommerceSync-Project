using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using ProductBridge.MVVM.Model;

namespace ProductBridge.Repositories
{
    public class ProductRepository
    {
        private string connectionString;

        public ProductRepository(string server, string database, string username, string password)
        {
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        public IEnumerable<Product> GetAllProductsFromDatabase()
        {
            List<Product> products = new List<Product>();

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";

                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = reader.GetInt32("ProductId"),
                                ProductName = reader.GetString("ProductName"),
                                Price = reader.GetDecimal("Price"),
                                SalesPrice = reader.GetDecimal("SalesPrice"),
                                Category = reader.GetString("Category"),
                                StockQuantity = reader.GetInt32("StockQuantity"),
                                SKU = reader.GetString("SKU"),
                                Tags = reader.GetString("Tags"),
                                ShortDescription = reader.GetString("ShortDescription"),
                                LongDescription = reader.GetString("LongDescription"),
                                ImageUrl = reader.GetString("ImageUrl"),
                                GalleryUrls = reader.GetString("GalleryUrls")
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public void InsertProduct(Product product)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (ProductName, Price, SalesPrice, Category, StockQuantity, SKU, Tags, ShortDescription, LongDescription, ImageUrl, GalleryUrls) VALUES (@ProductName, @Price, @SalesPrice, @Category, @StockQuantity, @SKU, @Tags, @ShortDescription, @LongDescription, @ImageUrl, @GalleryUrls)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@SalesPrice", product.SalesPrice);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                    command.Parameters.AddWithValue("@SKU", product.SKU);
                    command.Parameters.AddWithValue("@Tags", product.Tags);
                    command.Parameters.AddWithValue("@ShortDescription", product.ShortDescription);
                    command.Parameters.AddWithValue("@LongDescription", product.LongDescription);
                    command.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                    command.Parameters.AddWithValue("@GalleryUrls", product.GalleryUrls);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void DeleteProductFromDatabase(int productId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Products WHERE ProductId = @ProductId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Products SET ProductName = @ProductName, Price = @Price, SalesPrice = @SalesPrice, Category = @Category, StockQuantity = @StockQuantity, SKU = @SKU, Tags = @Tags, ShortDescription = @ShortDescription, LongDescription = @LongDescription, ImageUrl = @ImageUrl, GalleryUrls = @GalleryUrls WHERE ProductId = @ProductId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@SalesPrice", product.SalesPrice);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                    command.Parameters.AddWithValue("@SKU", product.SKU);
                    command.Parameters.AddWithValue("@Tags", product.Tags);
                    command.Parameters.AddWithValue("@ShortDescription", product.ShortDescription);
                    command.Parameters.AddWithValue("@LongDescription", product.LongDescription);
                    command.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                    command.Parameters.AddWithValue("@GalleryUrls", product.GalleryUrls);
                    command.Parameters.AddWithValue("@ProductId", product.ProductId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
    }
}
