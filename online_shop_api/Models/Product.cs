using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_shop_api.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

        // Navigation property to store
        [ForeignKey("StoreId")]
        public Store Store { get; set; }
    
        // Constructor
        public Product() { }
        public Product(int id, string name, string description, double price, string category, Store store)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Store = store;
        }
    }
    
}