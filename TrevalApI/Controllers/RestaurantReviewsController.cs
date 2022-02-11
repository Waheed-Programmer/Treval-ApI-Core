#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrevalApI.Data;
using TrevalApI.Models;

namespace TrevalApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RestaurantReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantReview>>> GetRestaurantReviews()
        {
            return await _context.RestaurantReviews.ToListAsync();
        }

        // GET: api/RestaurantReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantReview>> GetRestaurantReview(int id)
        {
            var restaurantReview = await _context.RestaurantReviews.FindAsync(id);

            if (restaurantReview == null)
            {
                return NotFound();
            }

            return restaurantReview;
        }

        // PUT: api/RestaurantReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantReview(int id, RestaurantReview restaurantReview)
        {
            if (id != restaurantReview.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurantReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RestaurantReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantReview>> PostRestaurantReview(RestaurantReview restaurantReview)
        {
            _context.RestaurantReviews.Add(restaurantReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantReview", new { id = restaurantReview.Id }, restaurantReview);
        }

        // DELETE: api/RestaurantReviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantReview(int id)
        {
            var restaurantReview = await _context.RestaurantReviews.FindAsync(id);
            if (restaurantReview == null)
            {
                return NotFound();
            }

            _context.RestaurantReviews.Remove(restaurantReview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantReviewExists(int id)
        {
            return _context.RestaurantReviews.Any(e => e.Id == id);
        }
    }
}
