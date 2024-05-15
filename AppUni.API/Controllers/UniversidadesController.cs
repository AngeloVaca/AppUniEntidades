using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppUni.Entidades;

namespace AppUni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversidadesController : ControllerBase
    {
        private readonly DbContext _context;

        public UniversidadesController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Universidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Universidad>>> GetUniversidad()
        {
            return await _context.Universidades.ToListAsync();
        }

        // GET: api/Universidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Universidad>> GetUniversidad(int id)
        {
            var universidad = await _context.Universidades.FindAsync(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/Universidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversidad(int id, Universidad universidad)
        {
            if (id != universidad.Id)
            {
                return BadRequest();
            }

            _context.Entry(universidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversidadExists(id))
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

        // POST: api/Universidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Universidad>> PostUniversidad(Universidad universidad)
        {
            _context.Universidades.Add(universidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversidad", new { id = universidad.Id }, universidad);
        }

        // DELETE: api/Universidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversidad(int id)
        {
            var universidad = await _context.Universidades.FindAsync(id);
            if (universidad == null)
            {
                return NotFound();
            }

            _context.Universidades.Remove(universidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniversidadExists(int id)
        {
            return _context.Universidades.Any(e => e.Id == id);
        }
    }
}
