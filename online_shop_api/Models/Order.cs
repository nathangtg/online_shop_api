using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_shop_api.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CartId { get; set; }

        // Navigation property  
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        // Constructor
        public Order() {}
        public Order(Cart cart, User user)
        {
            Cart = cart;
            CartId = cart.Id;
            User = user;
            UserId = user.Id;
        }
    }
}