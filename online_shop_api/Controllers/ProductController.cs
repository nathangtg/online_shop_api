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
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("products/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("products")]
        public IActionResult CreateProduct([FromBody] ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Category = productDto.Category
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("products/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Category = productDto.Category;

            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("products/{id}")]
        public IActionResult DeleteProduct(int id)
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

        [HttpGet("products/category/{category}")]
        public IActionResult GetProductsByCategory(string category)
        {
            var products = _context.Products.Where(p => p.Category == category).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("products/store/{store_id}")]
        public IActionResult GetProductsByStore(int store_id)
        {
            var products = _context.Products.Where(p => p.StoreId == store_id).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("products/store/{store_id}/category/{category}")]
        public IActionResult GetProductsByStoreAndCategory(int store_id, string category)
        {
            var products = _context.Products.Where(p => p.StoreId == store_id && p.Category == category).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("products/store/{store_id}/category/{category}/name/{name}")]
        public IActionResult GetProductsByStoreAndCategoryAndName(int store_id, string category, string name)
        {
            var products = _context.Products.Where(p => p.StoreId == store_id && p.Category == category && p.Name == name).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("products/store/{store_id}/name/{name}")]
        public IActionResult GetProductsByStoreAndName(int store_id, string name)
        {
            var products = _context.Products.Where(p => p.StoreId == store_id && p.Name == name).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("products/name/{name}")]
        public IActionResult GetProductsByName(string name)
        {
            var products = _context.Products.Where(p => p.Name == name).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("products/store/{store_id}/price/{price}")]
        public IActionResult GetProductsByStoreAndPrice(int store_id, double price)
        {
            var products = _context.Products.Where(p => p.StoreId == store_id && p.Price == price).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("products/price/{price}")]
        public IActionResult GetProductsByPrice(double price)
        {
            var products = _context.Products.Where(p => p.Price == price).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("products/store/{store_id}/category/{category}/price/{price}")]
        public IActionResult GetProductsByStoreAndCategoryAndPrice(int store_id, string category, double price)
        {
            var products = _context.Products.Where(p => p.StoreId == store_id && p.Category == category && p.Price == price).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("products/store/{store_id}/name/{name}/price/{price}")]
        public IActionResult GetProductsByStoreAndNameAndPrice(int store_id, string name, double price)
        {
            var products = _context.Products.Where(p => p.StoreId == store_id && p.Name == name && p.Price == price).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("products/store/{store_id}/category/{category}/name/{name}/price/{price}")]
        public IActionResult GetProductsByStoreAndCategoryAndNameAndPrice(int store_id, string category, string name, double price)
        {
            var products = _context.Products.Where(p => p.StoreId == store_id && p.Category == category && p.Name == name && p.Price == price).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("products/category/{category}/name/{name}/price/{price}")]
        public IActionResult GetProductsByCategoryAndNameAndPrice(string category, string name, double price)
        {
            var products = _context.Products.Where(p => p.Category == category && p.Name == name && p.Price == price).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

    }
}