using System.Windows;
using ProductBridge.MVVM.Model;
using ProductBridge.Repositories;
using ProductBridge.MVVM.View.Controllers;

namespace ProductBridge.MVVM.View
{
    public partial class EditProductWindow : Window
    {
        private readonly EditProductController _controller;

        public EditProductWindow(Product selectedProduct)
        {
            InitializeComponent();
            _controller = new EditProductController(selectedProduct, this);
            _controller.LoadProductData();
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.SaveChanges();
        }

        private void CancelChangesButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.CancelChanges();
        }
    }
}
