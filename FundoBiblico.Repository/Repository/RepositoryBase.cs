using FundoBiblico.Dominio.Interfaces.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace FundoBiblico.Repository.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly FundoBiblicoContext _context;
        public RepositoryBase(FundoBiblicoContext biblicoContext)
        {
            _context = biblicoContext;
        }

        public async Task Adicionar(TEntity entity)
        {
            await _context.AddAsync(entity);
            _context.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task Remover(TEntity entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
    }
}
