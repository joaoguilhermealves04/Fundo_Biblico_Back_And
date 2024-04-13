using FundoBiblico.Dominio.Entities;

namespace FundoBiblico.Dominio.Interfaces
{
    public interface ICompraRepository 
    {
        Task<Compra> ObterPorId(Guid id);
        Task Adicionar(Compra compra);
        void Atualizar(Compra compra);
        Task Remover(Compra compra);
        Task<IEnumerable<Compra>> ObterTodos();
    }
}
