using System;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Win32;
using ProductBridge.MVVM.Model;
using ProductBridge.Repositories;
using System.IO;
using ProductBridge.Controllers;


namespace ProductBridge.MVVM.View
{
    public partial class NewProductWindow : Window
    {
        public NewProductWindow()
        {
            InitializeComponent();
        }

        private void Upload_Product_Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSalesPrice.Text))
            {
                MessageBox.Show("Please enter a valid sales price.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtStockQuantity.Text))
            {
                MessageBox.Show("Please enter a valid stock quantity.");
                return;
            }

            string[] tagsArray = txtTags.Text.Split(',');
            ObservableCollection<string> tagsCollection = new ObservableCollection<string>(tagsArray);



            Product product = new Product()
            {
                ProductName = txtProductName.Text,
                Price = decimal.Parse(txtPrice.Text),
                SalesPrice = decimal.Parse(txtSalesPrice.Text),
                Category = cmbCategory.Text,
                StockQuantity = int.Parse(txtStockQuantity.Text),
                SKU = txtSKU.Text,
                Tags = txtTags.Text,
                ShortDescription = txtShortDescription.Text,
                LongDescription = txtLongDescription.Text,
                ImageUrl = "",
                GalleryUrls = "",
            };

            var productRepository = new ProductRepository(App.Server, App.Database, App.Username, App.Password);
            productRepository.InsertProduct(product);

            Close();
        }

        private void Upload_Image_Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|All Files (*.*)|*.*";
            openFileDialog.Multiselect = false;
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                var uploadImageController = new UploadImageController();
                uploadImageController.UploadImage(openFileDialog.FileName);
            }
        }

        private void Upload_Gallery_Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|All Files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                var uploadGalleryController = new UploadGalleryController();
                uploadGalleryController.UploadGallery(openFileDialog.FileNames);
            }
        }

        private void Cancel_Upload_Product_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}