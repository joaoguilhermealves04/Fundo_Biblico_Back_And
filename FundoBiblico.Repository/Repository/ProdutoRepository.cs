using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FundoBiblico.Repository.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly FundoBiblicoContext _context;
        public ProdutoRepository(FundoBiblicoContext fundoBiblico) 
        {
            _context = fundoBiblico;
        }

        public async Task Adicionar(Produto produto)
        {
            await _context.AddAsync(produto);
            _context.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
           _context.Update(produto);
           _context.SaveChanges();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.Set<Produto>().FirstAsync(x => x.Id == id);
        }

        public async Task<Produto> ObterPorNome(string? Nome)
        {
            var consultaProdutoNome= await _context.Set<Produto>()
                    .FirstOrDefaultAsync(x => x.Nome.ToLower().Contains(Nome.ToLower()) && x.QuantidadeEstoque != 0);
            return consultaProdutoNome;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await  _context.Set<Produto>().ToListAsync();
        }

        public async Task Remover(Produto produto)
        {
            _context.Remove(produto);
            _context.SaveChanges(); 
        }
    }
}
