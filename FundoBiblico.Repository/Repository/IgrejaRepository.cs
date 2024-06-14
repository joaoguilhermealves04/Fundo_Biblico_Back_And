using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FundoBiblico.Repository.Repository
{
    public class IgrejaRepository : IIgrejaRepository
    {
        private readonly FundoBiblicoContext _context;
        public IgrejaRepository(FundoBiblicoContext fundoBiblicoContext)
        {
            _context = fundoBiblicoContext;
        }

        public async Task Adicionar(Igreja igreja)
        {
            await _context.AddAsync(igreja);
            await _context.SaveChangesAsync();
        }

        public async void Atualizar(Igreja igreja)
        {
            _context.Update(igreja);
            await _context.SaveChangesAsync();
        }

        public async Task<Igreja> ObterPorId(Guid id)
        {
            return await _context.Igrejas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Igreja> ObterPorNome(string nome)
        {
            return await _context.Igrejas.FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task<IEnumerable<Igreja>> ObterTodos()
        {
            return await _context.Igrejas.ToListAsync();
        }

        public async Task Remover(Igreja igreja)
        {
            _context.Remove(igreja);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
