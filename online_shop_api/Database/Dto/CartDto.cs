using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace online_shop_api.Database.Dto
{
    public class CartDto
    {
        [Required]
        public List<CartProductDto> CartProducts { get; set; }

        [Required]
        public double TotalPrice { get; set; }    
    }
}