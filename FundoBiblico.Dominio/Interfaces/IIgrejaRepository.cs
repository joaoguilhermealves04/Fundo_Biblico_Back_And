using FundoBiblico.Dominio.Entity;

namespace FundoBiblico.Dominio.Interfaces
{
    public interface IIgrejaRepository
    {
        Task<Igreja> ObterPorId(Guid id);
        Task Adicionar(Igreja igreja);
        void Atualizar(Igreja igreja);
        Task Remover(Igreja igreja);
        Task<IEnumerable<Igreja>> ObterTodos();
        Task<Igreja>ObterPorNome (string nome); 
    }
}
