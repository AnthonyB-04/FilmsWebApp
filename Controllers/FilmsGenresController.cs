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
    public class FilmsGenresController : ControllerBase
    {
        private readonly Lab2FilmsContext _context;

        public FilmsGenresController(Lab2FilmsContext context)
        {
            _context = context;
        }

        // GET: api/FilmsGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmsGenres>>> GetFilmsGenres()
        {
            return await _context.FilmsGenres.ToListAsync();
        }

        // GET: api/FilmsGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmsGenres>> GetFilmsGenres(int id)
        {
            var filmsGenres = await _context.FilmsGenres.FindAsync(id);

            if (filmsGenres == null)
            {
                return NotFound();
            }

            return filmsGenres;
        }

        // PUT: api/FilmsGenres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmsGenres(int id, FilmsGenres filmsGenres)
        {
            if (id != filmsGenres.FilmsGenresId)
            {
                return BadRequest();
            }

            _context.Entry(filmsGenres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmsGenresExists(id))
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

        // POST: api/FilmsGenres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmsGenres>> PostFilmsGenres(FilmsGenres filmsGenres)
        {
            _context.FilmsGenres.Add(filmsGenres);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmsGenres", new { id = filmsGenres.FilmsGenresId }, filmsGenres);
        }

        // DELETE: api/FilmsGenres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmsGenres(int id)
        {
            var filmsGenres = await _context.FilmsGenres.FindAsync(id);
            if (filmsGenres == null)
            {
                return NotFound();
            }

            _context.FilmsGenres.Remove(filmsGenres);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmsGenresExists(int id)
        {
            return _context.FilmsGenres.Any(e => e.FilmsGenresId == id);
        }
    }
}
