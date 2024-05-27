using API_BancAtlan_EstadoCuenta.Entities;
using API_BancAtlan_EstadoCuenta.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API_BancAtlan_EstadoCuenta.Repositories
{

    public class ClienteRepository : IFacadeRepository<Cliente>
    {
        private readonly BancAtlanEstadoCuentaContext _context;

        public ClienteRepository(BancAtlanEstadoCuentaContext context) { 
            _context = context;
        }

        public async void Delete(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if(cliente == null)
            {
                throw new NotFoundException("Cliente no encontrado");
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> FindById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                throw new NotFoundException("Cliente no encontrado");
            }
            return cliente;
        }

        public async Task<Cliente> GetById(int id)
        {
            return await FindById(id);
        }

        public async Task<Cliente?> Insert(Cliente cliente)
        {
            EntityEntry<Cliente> insertedCliente = await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return insertedCliente.Entity;
        }

        public async void Update(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                throw new ApiException("Cliente no coincide con id");
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    throw new NotFoundException("Cliente no encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
