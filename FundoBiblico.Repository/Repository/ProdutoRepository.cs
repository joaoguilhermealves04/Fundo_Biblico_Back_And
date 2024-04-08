using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;
using FundoBiblico.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Repository.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        private readonly FundoBiblicoContext _context;
        public ProdutoRepository(FundoBiblicoContext fundoBiblico) : base(fundoBiblico)
        {
            _context = fundoBiblico;
        }
        public async Task<Produto> ObterPorNome(string? Nome)
        {
            var consultaProdutoNome= await _context.Set<Produto>()
                    .FirstOrDefaultAsync(x => x.Nome.ToLower() == Nome.ToLower() && x.QuantidadeEstoque != 0);
            return consultaProdutoNome;
        }
    }
}
