using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ProductBridge.MVVM.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal SalesPrice { get; set; }
        public string Category { get; set; }
        public int StockQuantity { get; set; }
        public string SKU { get; set; }
        public string Tags { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public string GalleryUrls { get; set; }
    }
    
   
 }
