using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_shop_api.Models
{
    public class CartProduct
    {
        [Key]
        public int Id { get; set; }

        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public CartProduct() { }

        public CartProduct(int cartId, int productId, int quantity)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}