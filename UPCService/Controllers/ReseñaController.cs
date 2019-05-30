using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPCService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UPCService.Controllers
{
    [Produces("application/json")]
    [Route("api/reseñas")]
    public class ReseñaController : Controller
    {

    
        private readonly ProyectoDBContext _context;
        public ReseñaController(ProyectoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Reseña> GetReseña()
        {
            return _context.Reseñas;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReseña([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentReseña = await _context.Reseñas.SingleOrDefaultAsync(p => p.Id == id);

            if (currentReseña == null)
            {
                return NotFound();
            }
            return Ok(currentReseña);
        }

        [HttpPost]
        public async Task<IActionResult> PostReseña([FromBody] Reseña usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Reseñas.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReseña", new { id = usuario.Id }, usuario);

        }

        private bool ExisteReseña(int id)
        {
            return _context.Reseñas.Any(p => p.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReseña([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentReseña = await _context.Reseñas.SingleOrDefaultAsync(p => p.Id == id);

            if (currentReseña == null)
            {
                return NotFound();
            }

            _context.Reseñas.Remove(currentReseña);
            await _context.SaveChangesAsync();

            return Ok(currentReseña);
        }

    }
}