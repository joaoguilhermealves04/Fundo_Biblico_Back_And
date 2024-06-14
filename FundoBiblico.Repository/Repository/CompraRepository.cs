using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FundoBiblico.Repository.Repository
{
    public class CompraRepository : ICompraRepository
    {
        private readonly FundoBiblicoContext _context;
        public CompraRepository(FundoBiblicoContext fundoBiblico)
        {
            _context = fundoBiblico;
        }

        public async Task Adicionar(Compra compra)
        {
            await _context.AddAsync(compra);
            await _context.SaveChangesAsync();
        }

        public async void Atualizar(Compra compra)
        {
            _context.Update(compra);
            await _context.SaveChangesAsync();
        }

        public async Task<Compra> ObterPorId(Guid id)
        {
            return await _context.Set<Compra>().FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Compra>> ObterTodos()
        {
            return await _context.Set<Compra>().ToListAsync();
        }

        public async Task Remover(Compra compra)
        {
            _context.Remove(compra);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
