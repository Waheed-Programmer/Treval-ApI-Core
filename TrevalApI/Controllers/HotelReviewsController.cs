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
    public class HotelReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HotelReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelReview>>> GethotelReviews()
        {
            return await _context.hotelReviews.ToListAsync();
        }

        // GET: api/HotelReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelReview>> GetHotelReview(int id)
        {
            var hotelReview = await _context.hotelReviews.FindAsync(id);

            if (hotelReview == null)
            {
                return NotFound();
            }

            return hotelReview;
        }

        // PUT: api/HotelReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelReview(int id, HotelReview hotelReview)
        {
            if (id != hotelReview.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelReviewExists(id))
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

        // POST: api/HotelReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelReview>> PostHotelReview(HotelReview hotelReview)
        {
            _context.hotelReviews.Add(hotelReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelReview", new { id = hotelReview.Id }, hotelReview);
        }

        // DELETE: api/HotelReviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelReview(int id)
        {
            var hotelReview = await _context.hotelReviews.FindAsync(id);
            if (hotelReview == null)
            {
                return NotFound();
            }

            _context.hotelReviews.Remove(hotelReview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelReviewExists(int id)
        {
            return _context.hotelReviews.Any(e => e.Id == id);
        }
    }
}
