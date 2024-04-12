using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;
using FundoBiblico.Dominio.Models;
using FundoBiblico.Repository.Data;

namespace FundoBiblico.Aplication.Servicos
{
    public class ClienteServicos : IClienteServicos
    {
        private readonly IClienteRepositroy _clienteRepositroy;
        private readonly FundoBiblicoContext _context;
        public ClienteServicos(IClienteRepositroy clienteRepositroy, FundoBiblicoContext fundoBiblicoContext)
        {
            _clienteRepositroy = clienteRepositroy;
            _context = fundoBiblicoContext;
        }       

        public async Task CadastroCliente(ClienteAddEditarModel clienteModel)
        {
            try
            {
                var clienteEntity = new Cliente(clienteModel.Nome, clienteModel.IgrejaPertencente);
                await _clienteRepositroy.Adicionar(clienteEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar no banco.", ex);
            }
        }

        public async Task AtualizarCliente(ClienteAddEditarModel clienteModel)
        {
            try
            {
                var clienteEntity = await _clienteRepositroy.ObterPorId(clienteModel.Id);

                clienteEntity.AtualizarEntidadeCliente(clienteModel.Nome, clienteModel.IgrejaPertencente);

                _clienteRepositroy.Atualizar(clienteEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar no banco.", ex);
            }
        }

        public async Task<ClienteModel> ObterCliente(Guid? id)
        {
            try
            {
                if (id == null)
                    throw new InvalidOperationException("Id não pode ser nulo.");

                var unicoCliente = await _clienteRepositroy.ObterPorId(id);

                var InformacaoDoCliente = new ClienteModel
                {
                    Id = unicoCliente.Id,
                    Nome = unicoCliente.Nome,
                    IgrejaPertencente = unicoCliente.IgrejaPertencente,
                    DataCadastro = unicoCliente.DataCadastro,
                    NumeroFilaEspera = unicoCliente.NumeroFilaEspera
                };

                return InformacaoDoCliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar o banco.", ex);
            }
        }

        public async Task<IEnumerable<ClienteModel>> ObterClientes()
        {
            try
            {
                var clientes = await _clienteRepositroy.ObterTodos();

                var trazerCliente = new List<ClienteModel>();

                foreach (var c in clientes)
                {
                    var clienteRetorno = new ClienteModel
                    {
                        Id = c.Id,
                        Nome = c.Nome,
                        IgrejaPertencente = c.IgrejaPertencente,
                        DataCadastro = c.DataCadastro,
                        NumeroFilaEspera = c.NumeroFilaEspera
                    };

                    trazerCliente.Add(clienteRetorno);
                }

                return trazerCliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar no banco", ex);
            }
        }
    }
}
