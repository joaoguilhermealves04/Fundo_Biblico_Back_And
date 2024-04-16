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
            _context.SaveChanges();
        }

        public async void Atualizar(Igreja igreja)
        {
             _context.Update(igreja);
            _context.SaveChanges();
        }

        public async Task<Igreja> ObterPorId(Guid id)
        {
           return await _context.Igrejas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Igreja> ObterPorNome(string nome)
        {
            return await _context.Igrejas.FirstOrDefaultAsync(x =>x.Nome == nome);
        }

        public async Task<IEnumerable<Igreja>> ObterTodos()
        {
            return await _context.Igrejas.ToListAsync();
        }

        public async Task Remover(Igreja igreja)
        {
            _context.Remove(igreja);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
