using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPCService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UPCService.Controllers
{
    [Produces("application/json")]
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly ProyectoDBContext _context;
        public UsuarioController(ProyectoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetUsuario()
        {
            return _context.Usuarios;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentUsuario = await _context.Usuarios.SingleOrDefaultAsync(p => p.Id == id);

            if (currentUsuario == null)
            {
                return NotFound();
            }
            return Ok(currentUsuario);
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);

        }

        private bool ExisteUsuario(int id)
        {
            return _context.Usuarios.Any(p => p.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUsuario = await _context.Usuarios.SingleOrDefaultAsync(p => p.Id == id);

            if (currentUsuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(currentUsuario);
            await _context.SaveChangesAsync();

            return Ok(currentUsuario);
        }

    }
}