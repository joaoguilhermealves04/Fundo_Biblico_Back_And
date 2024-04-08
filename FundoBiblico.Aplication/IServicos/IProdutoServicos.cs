using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.IServicos
{
    public interface IProdutoServicos
    {
        Task CadastroProduto(ProdutoModel produto);
        Task Atualizar(ProdutoAddEditarModel produto);
        Task<IEnumerable<ProdutoModel>> ObterProdutos();
        Task<ProdutoModel> ObterProduto(Guid? id);
        Task Remover(Guid? id);
    }
}
