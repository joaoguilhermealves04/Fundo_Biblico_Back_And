using FundoBiblico.Aplication.Models;
using FundoBiblico.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.IServicos
{
    public interface IClienteServicos
    {
        Task CadastroCliente(ClienteAddEditarModel cliente);
        Task AtualizarCliente(ClienteAddEditarModel cliente);
        Task<IEnumerable<ClienteModel>> ObterClientes();
        Task<ClienteModel> ObterCliente(Guid id);
        Task Remover(Guid id);
    }
}
