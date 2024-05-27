using API_BancAtlan_EstadoCuenta.Entities;
using API_BancAtlan_EstadoCuenta.Exceptions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace API_BancAtlan_EstadoCuenta.Repositories
{
    public class TransaccionRepository : IFacadeRepository<Transaccion>
    {
        private readonly BancAtlanEstadoCuentaContext _context;

        public TransaccionRepository(BancAtlanEstadoCuentaContext context)
        {
            _context = context;
        }

        public async void Delete(Transaccion transaccion)
        {
            _context.Transaccions.Remove(transaccion);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var transaccion = await _context.Transaccions.FindAsync(id);
            if (transaccion == null)
            {
                throw new NotFoundException("Transaccion no encontrada");
            }
            _context.Transaccions.Remove(transaccion);
            await _context.SaveChangesAsync();
        }

        public async Task<Transaccion> FindById(int id)
        {
            var transaccion = await _context.Transaccions.FindAsync(id);
            if (transaccion == null)
            {
                throw new NotFoundException("Transaccion no encontrada");
            }
            return transaccion;
        }

        public async Task<Transaccion> GetById(int id)
        {
            return await FindById(id);
        }

        public async Task<Transaccion?> Insert(Transaccion transaccion)
        {
            EntityEntry<Transaccion> insertedTransaccion = await _context.Transaccions.AddAsync(transaccion);
            await _context.SaveChangesAsync();
            return insertedTransaccion.Entity;
        }

        public async void Update(int id, Transaccion transaccion)
        {
            if (id != transaccion.IdTransaccion)
            {
                throw new ApiException("Transaccion no coincide con id");
            }

            _context.Entry(transaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccionExists(id))
                {
                    throw new NotFoundException("Transaccion no encontrada");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool TransaccionExists(int id)
        {
            return _context.Transaccions.Any(e => e.IdTransaccion == id);
        }
    }
}
