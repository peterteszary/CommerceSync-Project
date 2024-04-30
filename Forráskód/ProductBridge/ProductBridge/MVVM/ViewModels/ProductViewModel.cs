using System.Collections.ObjectModel;
using ProductBridge.MVVM.Model;
using ProductBridge.MVVM.ViewModels;
using ProductBridge.Repositories;

namespace ProductBridge.MVVM.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        private ObservableCollection<Product> _products;
        private ProductRepository _productRepository;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ProductViewModel(ProductRepository productRepository)
        {
            _productRepository = productRepository;
            LoadProducts();
        }

        private void LoadProducts()
        {
            Products = new ObservableCollection<Product>(_productRepository.GetAllProductsFromDatabase());
        }

        public void AddProduct(Product product)
        {
            _productRepository.InsertProduct(product);
            LoadProducts(); // Frissítjük a termékek listáját a hozzáadás után
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProductFromDatabase(productId);
            LoadProducts(); // Frissítjük a termékek listáját a törlés után
        }
    }
}
