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
        Task CadastroIgreja(Produto produto);
        Task Atualizar(Produto produto);
        Task<IEnumerable<Produto>> ObterIgrejas();
        Task<Produto> ObterIgreja(Guid? id);
        Task Remover(Guid? id);
    }
}
