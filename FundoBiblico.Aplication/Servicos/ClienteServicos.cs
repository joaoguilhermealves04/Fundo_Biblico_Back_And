using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;

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
                var clienteEntity = new Cliente(clienteModel.Nome);
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
                var clienteEntity = _clienteRepositroy.ObterPorId(clienteModel.Id);

                clienteEntity.Result.AtualizarEntidadeCliente(clienteModel.Nome);

                _clienteRepositroy.Atualizar(clienteEntity.Result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar no banco.", ex);
            }
        }

        public async Task<ClienteModel> ObterCliente(Guid id)
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
                    DataCadastro = unicoCliente.DataCadastro
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
                        DataCadastro = c.DataCadastro
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

        public Task Remover(Guid id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentNullException("Id não pode ser nulo.");

                var cliente = _clienteRepositroy.ObterPorId(id);
                if (cliente == null)
                    throw new Exception("Produto não encontrado");

                _clienteRepositroy.Remover(cliente.Result);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw new Exception("Problem em remover o cliente.",ex);
            }
        }
    }
}
