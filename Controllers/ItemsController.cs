using System;
using AutoHub.Data;
using AutoHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly AuctionContext _context;

        public ItemsController(AuctionContext context)
        {
            _context = context;
        }

        // Ttest database connection
        [HttpGet("test-connection")]
        public async Task<IActionResult> TestDatabaseConnection()
        {
            try
            {
                // Attempt to connect to the database
                await _context.Database.CanConnectAsync();
                return Ok("Connection successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection failed: {ex.Message}");
            }
        }

        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<Item>> InsertItem([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            var item_id = item.Id;
            var item_name = item.Name;

            Console.WriteLine("#--Item Found--#\n-Product ID: " + item_id + " \n-Product name: " + item_name);

            return item;
        }
    }
}

