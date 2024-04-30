using System;
using ProductBridge.MVVM.Model;
using ProductBridge.Repositories;
using System.Windows;

namespace ProductBridge.MVVM.View.Controllers
{
    public class EditProductController
    {
        private readonly Product _selectedProduct;
        private readonly EditProductWindow _view;

        public EditProductController(Product selectedProduct, EditProductWindow view)
        {
            _selectedProduct = selectedProduct;
            _view = view;
        }

        public void LoadProductData()
        {
            if (_selectedProduct != null)
            {
                _view.txtProductName.Text = _selectedProduct.ProductName;
                _view.txtPrice.Text = _selectedProduct.Price.ToString();
                _view.txtSalesPrice.Text = _selectedProduct.SalesPrice.ToString();
                _view.cmbCategory.Text = _selectedProduct.Category;
                _view.txtStockQuantity.Text = _selectedProduct.StockQuantity.ToString();
                _view.txtSKU.Text = _selectedProduct.SKU;
                _view.txtShortDescription.Text = _selectedProduct.ShortDescription;
                _view.txtLongDescription.Text = _selectedProduct.LongDescription;
            }
        }

        public void SaveChanges()
        {
            if (_selectedProduct != null)
            {
                _selectedProduct.ProductName = _view.txtProductName.Text;
                _selectedProduct.Price = decimal.Parse(_view.txtPrice.Text);
                _selectedProduct.SalesPrice = decimal.Parse(_view.txtSalesPrice.Text);
                _selectedProduct.Category = _view.cmbCategory.Text;
                _selectedProduct.StockQuantity = int.Parse(_view.txtStockQuantity.Text);
                _selectedProduct.SKU = _view.txtSKU.Text;
                _selectedProduct.ShortDescription = _view.txtShortDescription.Text;
                _selectedProduct.LongDescription = _view.txtLongDescription.Text;

                var productRepository = new ProductRepository(App.Server, App.Database, App.Username, App.Password);
                productRepository.UpdateProduct(_selectedProduct);

                _view.Close();
            }
        }

        public void CancelChanges()
        {
            _view.Close();
        }
    }
}
