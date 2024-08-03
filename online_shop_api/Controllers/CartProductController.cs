using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using online_shop_api.Database;
using online_shop_api.Database.Dto;
using online_shop_api.Models;

namespace online_shop_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("cartproducts")]
        public IActionResult GetCartProducts()
        {
            return Ok(_context.CartProducts.ToList());
        }

        [HttpGet("cartproducts/{id}")]
        public IActionResult GetCartProduct(int id)
        {
            var cartProduct = _context.CartProducts.FirstOrDefault(cp => cp.Id == id);

            if (cartProduct == null)
            {
                return NotFound();
            }

            return Ok(cartProduct);
        }

        [HttpPost("cartproducts")]
        public IActionResult AddProductToCart([FromBody] CartProductDto cartProductDto)
        {
            var cartProduct = new CartProduct
            {
                ProductId = cartProductDto.ProductId,
                Quantity = cartProductDto.Quantity
            };

            _context.CartProducts.Add(cartProduct);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCartProduct), new { id = cartProduct.Id }, cartProduct);
        }

        [HttpPut("cartproducts/{id}")]
        public IActionResult UpdateCartProduct(int id, [FromBody] CartProductDto cartProductDto)
        {
            var existingCartProduct = _context.CartProducts.FirstOrDefault(cp => cp.Id == id);

            if (existingCartProduct == null)
            {
                return NotFound();
            }

            existingCartProduct.ProductId = cartProductDto.ProductId;
            existingCartProduct.Quantity = cartProductDto.Quantity;

            _context.SaveChanges();

            return Ok(existingCartProduct);
        }

        [HttpDelete("cartproducts/{id}")]
        public IActionResult DeleteCartProduct(int id)
        {
            var cartProduct = _context.CartProducts.FirstOrDefault(cp => cp.Id == id);

            if (cartProduct == null)
            {
                return NotFound();
            }

            _context.CartProducts.Remove(cartProduct);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("cartproducts")]
        public IActionResult DeleteAllCartProducts()
        {
            _context.CartProducts.RemoveRange(_context.CartProducts);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("cartproducts/cart/{cartId}")]
        public IActionResult GetCartProductsByCartId(int cartId)
        {
            var cartProducts = _context.CartProducts.Where(cp => cp.CartId == cartId).ToList();

            if (cartProducts == null)
            {
                return NotFound();
            }

            return Ok(cartProducts);
        }

    }
}