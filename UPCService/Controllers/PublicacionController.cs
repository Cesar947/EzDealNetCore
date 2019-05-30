using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPCService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UPCService.Controllers
{
    [Produces("application/json")]
    [Route("api/publicaciones")]
    public class PublicacionController : Controller
    {
        private readonly ProyectoDBContext _context;
        public PublicacionController(ProyectoDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Publicacion> GetPublicaciones()
        {
            return _context.Publicaciones;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublicacionPorId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentPublicacion = await _context.Publicaciones.SingleOrDefaultAsync(p => p.Id == id);

            if (currentPublicacion == null)
            {
                return NotFound();
            }
            return Ok(currentPublicacion);
        }

        
        [HttpPost]
        public async Task<IActionResult> PostPublicacion([FromBody] Publicacion publicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Publicaciones.Add(publicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicacionPorId", new { id = publicacion.Id }, publicacion);

        }

        private bool ExistePublicacion(int id)
        {
            return _context.Publicaciones.Any(p => p.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentPublicacion = await _context.Publicaciones.SingleOrDefaultAsync(p => p.Id == id);

            if (currentPublicacion == null)
            {
                return NotFound();
            }

            _context.Publicaciones.Remove(currentPublicacion);
            await _context.SaveChangesAsync();

            return Ok(currentPublicacion);
        }

    }
}

