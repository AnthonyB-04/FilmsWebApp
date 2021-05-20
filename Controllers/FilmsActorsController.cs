using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmsWebApp.Models;

namespace FilmsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsActorsController : ControllerBase
    {
        private readonly Lab2FilmsContext _context;

        public FilmsActorsController(Lab2FilmsContext context)
        {
            _context = context;
        }

        // GET: api/FilmsActors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmsActors>>> GetFilmsActors()
        {
            return await _context.FilmsActors.ToListAsync();
        }

        // GET: api/FilmsActors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmsActors>> GetFilmsActors(int id)
        {
            var filmsActors = await _context.FilmsActors.FindAsync(id);

            if (filmsActors == null)
            {
                return NotFound();
            }

            return filmsActors;
        }

        // PUT: api/FilmsActors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmsActors(int id, FilmsActors filmsActors)
        {
            if (id != filmsActors.FilmsActorsId)
            {
                return BadRequest();
            }

            _context.Entry(filmsActors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmsActorsExists(id))
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

        // POST: api/FilmsActors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmsActors>> PostFilmsActors(FilmsActors filmsActors)
        {
            _context.FilmsActors.Add(filmsActors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmsActors", new { id = filmsActors.FilmsActorsId }, filmsActors);
        }

        // DELETE: api/FilmsActors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmsActors(int id)
        {
            var filmsActors = await _context.FilmsActors.FindAsync(id);
            if (filmsActors == null)
            {
                return NotFound();
            }

            _context.FilmsActors.Remove(filmsActors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmsActorsExists(int id)
        {
            return _context.FilmsActors.Any(e => e.FilmsActorsId == id);
        }
    }
}
