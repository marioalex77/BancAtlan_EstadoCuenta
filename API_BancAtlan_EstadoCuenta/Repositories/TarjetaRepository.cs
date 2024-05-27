using API_BancAtlan_EstadoCuenta.Entities;
using API_BancAtlan_EstadoCuenta.Exceptions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace API_BancAtlan_EstadoCuenta.Repositories
{
    public class TarjetaRepository : IFacadeRepository<Tarjetum>
    {
        private readonly BancAtlanEstadoCuentaContext _context;

        public TarjetaRepository(BancAtlanEstadoCuentaContext context)
        {
            _context = context;
        }

        public async void Delete(Tarjetum tarjeta)
        {
            _context.Tarjeta.Remove(tarjeta);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var tarjeta = await _context.Tarjeta.FindAsync(id);
            if (tarjeta == null)
            {
                throw new NotFoundException("Tarjeta no encontrado");
            }
            _context.Tarjeta.Remove(tarjeta);
            await _context.SaveChangesAsync();
        }

        public async Task<Tarjetum> FindById(int id)
        {
            var tarjeta = await _context.Tarjeta.FindAsync(id);
            if (tarjeta == null)
            {
                throw new NotFoundException("Tarjeta no encontrado");
            }
            return tarjeta;
        }

        public async Task<Tarjetum> GetById(int id)
        {
            return await FindById(id);
        }

        public async Task<Tarjetum?> Insert(Tarjetum tarjeta)
        {
            EntityEntry<Tarjetum> insertedTarjeta = await _context.Tarjeta.AddAsync(tarjeta);
            await _context.SaveChangesAsync();
            return insertedTarjeta.Entity;
        }

        public async void Update(int id, Tarjetum tarjeta)
        {
            if (id != tarjeta.IdTarjeta)
            {
                throw new ApiException("Tarjeta no coincide con id");
            }

            _context.Entry(tarjeta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarjetaExists(id))
                {
                    throw new NotFoundException("Tarjeta no encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool TarjetaExists(int id)
        {
            return _context.Tarjeta.Any(e => e.IdTarjeta == id);
        }
    }
}
