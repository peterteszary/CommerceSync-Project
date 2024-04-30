using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProductBridge.MVVM.Model;
using ProductBridge.Repositories;

namespace ProductBridge.MVVM.View
{
    public partial class SearchProductView : Page
    {
        private List<Product> products;

        public SearchProductView()
        {
            InitializeComponent();
            LoadProductsFromDatabase();
        }

        private void LoadProductsFromDatabase()
        {
            try
            {
                
                ProductRepository productRepository = new ProductRepository(App.Server, App.Database, App.Username, App.Password);
                products = productRepository.GetAllProductsFromDatabase().ToList();

                
                productListBox.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a termékek betöltésekor: {ex.Message}");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Keresési feltételek alapján szűrés
                string productName = txtProductName.Text;
                string productId = txtProductID.Text;
                string productSKU = txtProductSKU.Text;
                string productCategory = txtProductCategory.Text;

                // Szűrt termékek kigyűjtése
                var filteredProducts = products.Where(product =>
                    product.ProductName.Contains(productName) &&
                    product.ProductId.ToString().Contains(productId) &&
                    product.SKU.Contains(productSKU) &&
                    product.Category.Contains(productCategory)
                ).ToList();

                // Szűrt termékek megjelenítése
                productListBox.ItemsSource = filteredProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a termékek keresésekor: {ex.Message}");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiválasztott termék törlése
                Product selectedProduct = (Product)productListBox.SelectedItem;
                if (selectedProduct != null)
                {
                    ProductRepository productRepository = new ProductRepository(App.Server, App.Database, App.Username, App.Password);
                    productRepository.DeleteProductFromDatabase(selectedProduct.ProductId);

                    // Termék eltávolítása a listából és ListBox frissítése
                    products.Remove(selectedProduct);
                    productListBox.ItemsSource = null;
                    productListBox.ItemsSource = products;
                }
                else
                {
                    MessageBox.Show("Nincs kiválasztott termék a törléshez.", "Nincs kiválasztva", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a termék törlésekor: {ex.Message}");
            }
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiválasztott termék módosítása
                Product selectedProduct = (Product)productListBox.SelectedItem;
                if (selectedProduct != null)
                {
                    // Az új ablak megnyitása a termék módosításához
                    EditProductWindow editProductWindow = new EditProductWindow(selectedProduct);
                    editProductWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kérem válassza ki a módosítandó terméket.", "Nincs kiválasztva", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a termék módosításakor: {ex.Message}");
            }
        }
    }
}
