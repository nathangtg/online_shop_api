using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace online_shop_api.Database.Dto
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
    }
}