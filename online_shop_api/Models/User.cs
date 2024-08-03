using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace online_shop_api.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
        
        // Constructor (if needed)
        public User() { }

        public User(string userName, string passwordHash, string role)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}