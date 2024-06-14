using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FundoBiblico.Repository.Repository
{
    public class ClienteRepository : IClienteRepositroy
    {
        private readonly FundoBiblicoContext _context;
        public ClienteRepository(FundoBiblicoContext fundoBiblicoContext)
        {
            _context = fundoBiblicoContext;
        }

        public async Task Adicionar(Cliente cliente)
        {
            await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async void Atualizar(Cliente cliente)
        {
            _context.Update(cliente);
           await _context.SaveChangesAsync();
        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            return await _context.Set<Cliente>().FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _context.Set<Cliente>().ToListAsync();
        }

        public async Task Remover(Cliente cliente)
        {
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
