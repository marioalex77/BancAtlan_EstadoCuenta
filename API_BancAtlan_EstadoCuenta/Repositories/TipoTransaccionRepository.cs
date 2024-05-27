using API_BancAtlan_EstadoCuenta.Entities;
using API_BancAtlan_EstadoCuenta.Exceptions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace API_BancAtlan_EstadoCuenta.Repositories
{
    public class TipoTransaccionRepository : IFacadeRepository<TipoTransaccion>
    {
        private readonly BancAtlanEstadoCuentaContext _context;

        public TipoTransaccionRepository(BancAtlanEstadoCuentaContext context)
        {
            _context = context;
        }

        public async void Delete(TipoTransaccion tipoTransaccion)
        {
            _context.TipoTransaccions.Remove(tipoTransaccion);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var tipoTransaccion = await _context.TipoTransaccions.FindAsync(id);
            if (tipoTransaccion == null)
            {
                throw new NotFoundException("Tipo transaccion no encontrado");
            }
            _context.TipoTransaccions.Remove(tipoTransaccion);
            await _context.SaveChangesAsync();
        }

        public async Task<TipoTransaccion> FindById(int id)
        {
            var tipoTransaccion = await _context.TipoTransaccions.FindAsync(id);
            if (tipoTransaccion == null)
            {
                throw new NotFoundException("Tipo transaccion no encontrado");
            }
            return tipoTransaccion;
        }

        public async Task<TipoTransaccion> GetById(int id)
        {
            return await FindById(id);
        }

        public async Task<TipoTransaccion?> Insert(TipoTransaccion tipoTransaccion)
        {
            EntityEntry<TipoTransaccion> insertedTipoTransaccion = await _context.TipoTransaccions.AddAsync(tipoTransaccion);
            await _context.SaveChangesAsync();
            return insertedTipoTransaccion.Entity;
        }

        public async void Update(int id, TipoTransaccion tipoTransaccion)
        {
            if (id != tipoTransaccion.IdTipoTransaccion)
            {
                throw new ApiException("Tipo transaccion no coincide con id");
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
                    throw new NotFoundException("Tipo transaccion no encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool TipoTransaccionExists(int id)
        {
            return _context.TipoTransaccions.Any(e => e.IdTipoTransaccion == id);
        }
    }
}
