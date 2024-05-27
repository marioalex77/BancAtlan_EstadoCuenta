using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_BancAtlan_EstadoCuenta.Entities;

namespace API_BancAtlan_EstadoCuenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTransaccionsController : ControllerBase
    {
        private readonly BancAtlanEstadoCuentaContext _context;

        public TipoTransaccionsController(BancAtlanEstadoCuentaContext context)
        {
            _context = context;
        }

        // GET: api/TipoTransaccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTransaccion>>> GetTipoTransaccions()
        {
            return await _context.TipoTransaccions.ToListAsync();
        }

        // GET: api/TipoTransaccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTransaccion>> GetTipoTransaccion(int id)
        {
            var tipoTransaccion = await _context.TipoTransaccions.FindAsync(id);

            if (tipoTransaccion == null)
            {
                return NotFound();
            }

            return tipoTransaccion;
        }

        // PUT: api/TipoTransaccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoTransaccion(int id, TipoTransaccion tipoTransaccion)
        {
            if (id != tipoTransaccion.IdTipoTransaccion)
            {
                return BadRequest();
            }

            _context.Entry(tipoTransaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTransaccionExists(id))
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

        // POST: api/TipoTransaccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoTransaccion>> PostTipoTransaccion(TipoTransaccion tipoTransaccion)
        {
            _context.TipoTransaccions.Add(tipoTransaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoTransaccion", new { id = tipoTransaccion.IdTipoTransaccion }, tipoTransaccion);
        }

        // DELETE: api/TipoTransaccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoTransaccion(int id)
        {
            var tipoTransaccion = await _context.TipoTransaccions.FindAsync(id);
            if (tipoTransaccion == null)
            {
                return NotFound();
            }

            _context.TipoTransaccions.Remove(tipoTransaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoTransaccionExists(int id)
        {
            return _context.TipoTransaccions.Any(e => e.IdTipoTransaccion == id);
        }
    }
}
