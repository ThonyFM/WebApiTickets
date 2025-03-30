using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTickets.DataBase;
using WebApiTickets.Models;

namespace WebApiTickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiquetesController : ControllerBase
    {
        private readonly ContextoBD _contexto;

        public TiquetesController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiquetes>>> GetTiquetes()
        {
            return await _contexto.listaTiquetes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tiquetes>> GetTiquete(int id)
        {
            var tiquete = await _contexto.listaTiquetes.FindAsync(id);
            if (tiquete == null)
            {
                return NotFound();
            }
            return tiquete;
        }

        [HttpPost]
        public async Task<ActionResult<Tiquetes>> PostTiquete(Tiquetes tiquete)
        {
            _contexto.listaTiquetes.Add(tiquete);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTiquete), new { id = tiquete.ti_identificador }, tiquete);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiquete(int id, Tiquetes tiquete)
        {
            if (id != tiquete.ti_identificador)
            {
                return BadRequest();
            }

            _contexto.Entry(tiquete).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiqueteExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiquete(int id)
        {
            var tiquete = await _contexto.listaTiquetes.FindAsync(id);
            if (tiquete == null)
            {
                return NotFound();
            }

            _contexto.listaTiquetes.Remove(tiquete);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool TiqueteExists(int id)
        {
            return _contexto.listaTiquetes.Any(e => e.ti_identificador == id);
        }
    }
}
