using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTickets.DataBase;
using WebApiTickets.Models;

namespace WebApiTickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ContextoBD _contexto;

        public UsuariosController(ContextoBD contexto)
        {
            _contexto = contexto;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            return await _contexto.listaUsuarios.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuario(int id)
        {
            var usuario = await _contexto.listaUsuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario(Usuarios usuario)
        {

            var rol = await _contexto.Roles.FindAsync(usuario.us_ro_identificador);

            if (rol == null)
            {
                return NotFound("Rol no encontrado");
            }

            usuario.Roles = rol;


            _contexto.listaUsuarios.Add(usuario);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.us_identificador }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuarios usuario)
        {
            if (id != usuario.us_identificador)
            {
                return BadRequest();
            }

            _contexto.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _contexto.listaUsuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _contexto.listaUsuarios.Remove(usuario);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _contexto.listaUsuarios.Any(e => e.us_identificador == id);
        }
    }
}
