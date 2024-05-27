using API_BancAtlan_EstadoCuenta.Entities;
using API_BancAtlan_EstadoCuenta.Exceptions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace API_BancAtlan_EstadoCuenta.Repositories
{
    public class EstadoCuentaRepository : IFacadeRepository<EstadoCuentum>
    {
        private readonly BancAtlanEstadoCuentaContext _context;

        public EstadoCuentaRepository(BancAtlanEstadoCuentaContext context)
        {
            _context = context;
        }

        public async void Delete(EstadoCuentum estadoCuenta)
        {
            _context.EstadoCuenta.Remove(estadoCuenta);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var estadoCuenta = await _context.EstadoCuenta.FindAsync(id);
            if (estadoCuenta == null)
            {
                throw new NotFoundException("Estado cuenta no encontrado");
            }
            _context.EstadoCuenta.Remove(estadoCuenta);
            await _context.SaveChangesAsync();
        }

        public async Task<EstadoCuentum> FindById(int id)
        {
            var estadoCuenta = await _context.EstadoCuenta.FindAsync(id);
            if (estadoCuenta == null)
            {
                throw new NotFoundException("Estado cuenta no encontrado");
            }
            return estadoCuenta;
        }

        public async Task<EstadoCuentum> GetById(int id)
        {
            return await FindById(id);
        }

        public async Task<EstadoCuentum?> Insert(EstadoCuentum estadoCuenta)
        {
            EntityEntry<EstadoCuentum> insertedEstadoCuenta = await _context.EstadoCuenta.AddAsync(estadoCuenta);
            await _context.SaveChangesAsync();
            return insertedEstadoCuenta.Entity;
        }

        public async void Update(int id, EstadoCuentum estadoCuenta)
        {
            if (id != estadoCuenta.IdEstadoCuenta)
            {
                throw new ApiException("Estado cuenta no coincide con id");
            }

            _context.Entry(estadoCuenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoCuentaExists(id))
                {
                    throw new NotFoundException("Estado cuenta no encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool EstadoCuentaExists(int id)
        {
            return _context.EstadoCuenta.Any(e => e.IdEstadoCuenta == id);
        }
    }
}
