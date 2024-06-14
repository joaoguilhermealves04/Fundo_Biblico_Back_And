using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Repository.Repository
{
    public class IgrejaProdutoRepository : IIgrejaProdutoRepository
    {
        private readonly FundoBiblicoContext _context;
        public IgrejaProdutoRepository(FundoBiblicoContext fundoBiblicoContext)
        {
            _context = fundoBiblicoContext;
        }
        public async Task Adicionar(IgrejaProduto igrejaProduto)
        {
            await _context.AddAsync(igrejaProduto);
            await _context.SaveChangesAsync();
        }

        public async void Atualizar(IgrejaProduto igrejaProduto)
        {
            _context.Update(igrejaProduto);
            await _context.SaveChangesAsync();
        }

        public async Task<IgrejaProduto> ObterPorId(Guid id)
        {
            return await _context.Set<IgrejaProduto>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<IgrejaProduto>> ObterTodos()
        {
            return await _context.Set<IgrejaProduto>().ToListAsync();
        }

        public async Task Remover(IgrejaProduto igrejaProduto)
        {
            _context.Remove(igrejaProduto);
            await _context.SaveChangesAsync();
        }
    }
}
