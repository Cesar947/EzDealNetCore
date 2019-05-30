using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPCService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UPCService.Controllers
{
    [Produces("application/json")]
    [Route("api/solicitudes")]
    public class SolicitudController : Controller
    {
        private readonly ProyectoDBContext _context;
        public SolicitudController(ProyectoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Solicitud> GetSolicitud()
        {
            return _context.Solicitudes;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSolicitud([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentSolicitud = await _context.Solicitudes.SingleOrDefaultAsync(p => p.Id == id);

            if (currentSolicitud == null)
            {
                return NotFound();
            }
            return Ok(currentSolicitud);
        }

        [HttpPost]
        public async Task<IActionResult> PostSolicitud([FromBody] Solicitud solicitud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitud", new { id = solicitud.Id }, solicitud);

        }

        private bool ExisteSolicitud(int id)
        {
            return _context.Solicitudes.Any(p => p.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentSolicitud = await _context.Solicitudes.SingleOrDefaultAsync(p => p.Id == id);

            if (currentSolicitud == null)
            {
                return NotFound();
            }

            _context.Solicitudes.Remove(currentSolicitud);
            await _context.SaveChangesAsync();

            return Ok(currentSolicitud);
        }

    }
}