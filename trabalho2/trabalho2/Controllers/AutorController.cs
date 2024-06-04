using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trabalho2.Models;
using trabalho2.Data;
using trabalho2.Models;

namespace trabalho2.Controllers
{
    [Route("api/[AutorController]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly LivrariaContext _context;
        private readonly object autor;

        public AutorController(LivrariaContext context)
        {
            _context = context;
        }

        // GET: api/Autor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAuthors()
        {
            return await _context.Autores.Include(a => a.Livro).ToListAsync();
        }

        // GET: api/Autor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAuthor(int id)
        {
            var author = await _context.Autores.Include(a => a.Livro).FirstOrDefaultAsync(a => a.AutorId == id);

            if (autor == null)
            {
                return NotFound();
            }

            return (ActionResult<Autor>)autor;
        }

        // POST: api/Autor
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAuthor(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autor.AutorId }, autor);
        }

        // PUT: api/Autor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, Autor autor)
        {
            if (id != autor.AutorId)
            {
                return BadRequest();
            }

            _context.Entry(autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
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

        // DELETE: api/Autor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutorExists(int id)
        {
            return _context.Autores.Any(e => e.AutorId == id);
        }
    }
}
