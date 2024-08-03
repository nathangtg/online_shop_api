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

        public List<CartProduct> Products { get; set; }

        public double TotalPrice { get; set; }

        // Navigation property
        [ForeignKey("UserId")]
        public User User { get; set; }

        // Get total price of all products in the cart
        public void CalculateTotalPrice()
        {
            TotalPrice = 0;
            foreach (var product in Products)
            {
                TotalPrice += product.Product.Price * product.Quantity;
            }
        }

        public Cart() { }

        public Cart(string userId, List<CartProduct> products)
        {
            UserId = userId;
            Products = products;
            CalculateTotalPrice();
        }
    }
}