using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using online_shop_api.Database;
using online_shop_api.Models;

namespace online_shop_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public IActionResult GetStores()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("products/{id}")]
        public IActionResult GetStore(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("products")]
        public IActionResult CreateStore([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStore), new { id = product.Id }, product);
        }

        [HttpPut("products/{id}")]
        public IActionResult UpdateStore(int id, [FromBody] Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("products/{id}")]
        public IActionResult DeleteStore(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}