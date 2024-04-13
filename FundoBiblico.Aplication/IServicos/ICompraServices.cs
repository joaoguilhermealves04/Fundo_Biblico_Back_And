using FundoBiblico.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.IServicos
{
    public interface ICompraServices
    {
        Task CadastroCompra(CompraModel compra);
        Task Atualizar(CompraEditarAddModel compra);
        Task<IEnumerable<CompraModel>> ObterCompra();
        Task<CompraModel> ObterCompra(Guid id);
        Task Remover(Guid id);
    }
}
