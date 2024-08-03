using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using online_shop_api.Database;
using online_shop_api.Database.Dto;
using online_shop_api.Models;

namespace online_shop_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("carts")]
        public IActionResult GetCarts()
        {
            return Ok(_context.Carts.ToList());
        }

        [HttpGet("carts/{id}")]
        public IActionResult GetCart(int id)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [HttpPost("carts")]
        public IActionResult CreateCart([FromBody] CartDto cartDto)
        {
            var username = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            var userId = _context.Users.FirstOrDefault(u => u.UserName == username)?.Id ?? "";

            var cart = new Cart
            {
                UserId = userId
            };

            _context.Carts.Add(cart);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCart), new { id = cart.Id }, cart);
        }

        [HttpPut("carts/{id}")]
        public IActionResult UpdateCart(int id, [FromBody] CartDto cartDto)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);

            if (cart == null)
            {
                return NotFound();
            }

            cart.Products = cart.Products;
            cart.CalculateTotalPrice();

            _context.SaveChanges();

            return Ok(cart);
        }

        [HttpDelete("carts/{id}")]
        public IActionResult DeleteCart(int id)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);

            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("carts/{id}/products")]
        public IActionResult AddProductToCart(int id, [FromBody] CartProductDto cartProductDto)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);

            if (cart == null)
            {
                return NotFound();
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == cartProductDto.ProductId);

            if (product == null)
            {
                return NotFound();
            }

            var cartProduct = new CartProduct
            {
                Product = product,
                Quantity = cartProductDto.Quantity
            };

            cart.Products.Add(cartProduct);
            cart.CalculateTotalPrice();

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCart), new { id = cart.Id }, cart);
        }
    }
}