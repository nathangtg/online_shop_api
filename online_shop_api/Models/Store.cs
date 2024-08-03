using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_shop_api.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        // Navigation property
        [ForeignKey("UserId")]
        public User User { get; set; }       
        public List<Product> Products { get; set; }

        // Constructor
        public Store() { }
        public Store(List<Product> products, User user)
        {
            Products = products;
            User = user;
        }
    }
}