﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tourism.Models;

namespace Tourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBacksController : ControllerBase
    {
        private readonly TourismDbContext _context;

        public FeedBacksController(TourismDbContext context)
        {
            _context = context;
        }

        // GET: api/FeedBacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedBack>>> Getfeedbacks()
        {
          if (_context.feedbacks == null)
          {
              return NotFound();
          }
            return await _context.feedbacks.ToListAsync();
        }

        // GET: api/FeedBacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedBack>> GetFeedBack(int id)
        {
          if (_context.feedbacks == null)
          {
              return NotFound();
          }
            var feedBack = await _context.feedbacks.FindAsync(id);

            if (feedBack == null)
            {
                return NotFound();
            }

            return feedBack;
        }

        // PUT: api/FeedBacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedBack(int id, FeedBack feedBack)
        {
            if (id != feedBack.FId)
            {
                return BadRequest();
            }

            _context.Entry(feedBack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedBackExists(id))
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

        // POST: api/FeedBacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedBack>> PostFeedBack(FeedBack feedBack)
        {
          if (_context.feedbacks == null)
          {
              return Problem("Entity set 'TourismDbContext.feedbacks'  is null.");
          }
            _context.feedbacks.Add(feedBack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedBack", new { id = feedBack.FId }, feedBack);
        }

        // DELETE: api/FeedBacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedBack(int id)
        {
            if (_context.feedbacks == null)
            {
                return NotFound();
            }
            var feedBack = await _context.feedbacks.FindAsync(id);
            if (feedBack == null)
            {
                return NotFound();
            }

            _context.feedbacks.Remove(feedBack);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedBackExists(int id)
        {
            return (_context.feedbacks?.Any(e => e.FId == id)).GetValueOrDefault();
        }
    }
}
