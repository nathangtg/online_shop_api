using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_shop_api.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public List<Product> Products { get; set; }

        // Navigation property
        [ForeignKey("UserId")]
        public User User { get; set; }

        // Constructor
        public Cart() { }
        public Cart(int id, string userId, List<Product> products, User user)
        {
            Id = id;
            UserId = userId;
            Products = products;
            User = user;
        }
    }
}