using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tourism.Models;

namespace Tourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleriesController : ControllerBase
    {
        private readonly TourismDbContext _context;

        public GalleriesController(TourismDbContext context)
        {
            _context = context;
        }

        // GET: api/Galleries
         // Specify the required role(s) here

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gallery>>> Getgallery()
        {
          if (_context.gallery == null)
          {
              return NotFound();
          }
            return await _context.gallery.ToListAsync();
        }

        // GET: api/Galleries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gallery>> GetGallery(int? id)
        {
          if (_context.gallery == null)
          {
              return NotFound();
          }
            var gallery = await _context.gallery.FindAsync(id);

            if (gallery == null)
            {
                return NotFound();
            }

            return gallery;
        }

        // PUT: api/Galleries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGallery(int? id, Gallery gallery)
        {
            if (id != gallery.Id)
            {
                return BadRequest();
            }

            _context.Entry(gallery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryExists(id))
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

        // POST: api/Galleries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gallery>> PostGallery(Gallery gallery)
        {
          if (_context.gallery == null)
          {
              return Problem("Entity set 'TourismDbContext.gallery'  is null.");
          }
            _context.gallery.Add(gallery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGallery", new { id = gallery.Id }, gallery);
        }

        // DELETE: api/Galleries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGallery(int? id)
        {
            if (_context.gallery == null)
            {
                return NotFound();
            }
            var gallery = await _context.gallery.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }

            _context.gallery.Remove(gallery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GalleryExists(int? id)
        {
            return (_context.gallery?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("Invalid image data");
            }

            var gallery = new Gallery
            {
                ImageData = await GetBytesFromStreamAsync(image.OpenReadStream())
            };

            _context.gallery.Add(gallery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGallery", new { id = gallery.Id }, gallery);
        }

        private async Task<byte[]> GetBytesFromStreamAsync(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }
}
