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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        // Navigation property
        [ForeignKey("UserId")]
        public User User { get; set; }       
        public List<Product> Products { get; set; }

        // Constructor
        public Store() { }

        public Store(string userId, string name, string description, string address)
        {
            UserId = userId;
            Name = name;
            Description = description;
            Address = address;
        }
    }
}