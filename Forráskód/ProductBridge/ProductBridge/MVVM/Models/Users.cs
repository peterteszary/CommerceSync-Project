using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ProductBridge.MVVM.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }

       
    }
}
