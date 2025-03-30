using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTickets.DataBase;
using WebApiTickets.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly ContextoBD _contexto;

        public RolesController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
            return await _contexto.Roles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRol(int id)
        {
            var rol = await _contexto.Roles.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return rol;
        }

        [HttpPost]
        public async Task<ActionResult<Roles>> PostRol(Roles rol)
        {
            _contexto.Roles.Add(rol);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRol), new { id = rol.ro_identificador }, rol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, Roles rol)
        {
            if (id != rol.ro_identificador)
            {
                return BadRequest();
            }

            _contexto.Entry(rol).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
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
        public async Task<IActionResult> DeleteRol(int id)
        {
            var rol = await _contexto.Roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            _contexto.Roles.Remove(rol);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool RolExists(int id)
        {
            return _contexto.Roles.Any(e => e.ro_identificador == id);
        }
    }
}
