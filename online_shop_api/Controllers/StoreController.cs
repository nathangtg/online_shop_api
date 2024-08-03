using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using online_shop_api.Database;
using online_shop_api.Models;

namespace online_shop_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("stores")]
        public IActionResult GetStores()
        {
            return Ok(_context.Stores.ToList());
        }

        [HttpGet("stores/{id}")]
        public IActionResult GetStore(int id)
        {
            var store = _context.Stores.FirstOrDefault(s => s.Id == id);

            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        [HttpPost("stores")]
        public IActionResult CreateStore([FromBody] Store store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStore), new { id = store.Id }, store);
        }

        [HttpPut("stores/{id}")]
        public IActionResult UpdateStore(int id, [FromBody] Store store)
        {
            var existingStore = _context.Stores.FirstOrDefault(s => s.Id == id);

            if (existingStore == null)
            {
                return NotFound();
            }

            existingStore.Name = store.Name;
            existingStore.Address = store.Address;
            existingStore.Description = store.Description;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("stores/{id}")]
        public IActionResult DeleteStore(int id)
        {
            var store = _context.Stores.FirstOrDefault(s => s.Id == id);

            if (store == null)
            {
                return NotFound();
            }

            _context.Stores.Remove(store);
            _context.SaveChanges();

            return NoContent();
        }
    }
}