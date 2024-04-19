using FundoBiblico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Interfaces
{
    public interface IIgrejaProdutoRepository
    {
        Task<IgrejaProduto> ObterPorId(Guid id);
        Task Adicionar(IgrejaProduto igrejaProduto);
        void Atualizar(IgrejaProduto igrejaProduto);
        Task Remover(IgrejaProduto igrejaProduto);
        Task<IEnumerable<IgrejaProduto>> ObterTodos();
    }
}
