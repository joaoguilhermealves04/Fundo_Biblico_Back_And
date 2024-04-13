using FundoBiblico.Dominio.Entity;

namespace FundoBiblico.Dominio.Interfaces
{
    public interface IClienteRepositroy 
    {
        Task<Cliente> ObterPorId(Guid id);
        Task Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        Task Remover(Cliente cliente);
        Task<IEnumerable<Cliente>> ObterTodos();
    }
}
