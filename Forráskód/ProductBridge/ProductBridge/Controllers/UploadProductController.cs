using ProductBridge.MVVM.Model;
using ProductBridge.Repositories;

namespace ProductBridge.Controllers
{
    public class UploadProductController
    {
        public void UploadProduct(Product product)
        {
            var productRepository = new ProductRepository(App.Server, App.Database, App.Username, App.Password);
            productRepository.InsertProduct(product);
        }
    }
}
