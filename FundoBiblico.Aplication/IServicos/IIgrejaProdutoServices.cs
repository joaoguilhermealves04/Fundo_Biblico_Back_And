using FundoBiblico.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.IServicos
{
    public interface IIgrejaProdutoServices
    {
        Task CadastroIgrejaProduto(IgrejaProdutoAddEditarModel igrejaProduto);
        Task Atualizar(IgrejaProdutoAddEditarModel igrejaProduto);
        Task<IEnumerable<IgrejaProdutoModel>> ObterIgrejasProduto();
        Task<IgrejaProdutoModel> ObterIgrejaProduto(Guid? id);
        Task RemoverIgrejaProduto(Guid id);
    }
}
