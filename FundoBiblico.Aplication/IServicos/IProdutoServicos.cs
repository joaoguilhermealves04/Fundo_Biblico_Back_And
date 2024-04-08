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
        Task CadastroIgreja(ProdutoModel produto);
        Task Atualizar(ProdutoAddEditarModel produto);
        Task<IEnumerable<ProdutoModel>> ObterIgrejas();
        Task<ProdutoModel> ObterIgreja(Guid? id);
        Task Remover(Guid? id);
    }
}
