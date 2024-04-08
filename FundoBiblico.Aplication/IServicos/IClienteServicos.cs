using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Models;
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
        Task<IEnumerable<ClienteModel>> ObterClientes(ClienteModel cliente);
        Task<ClienteModel> ObterCliente(Guid? id);
    }
}
