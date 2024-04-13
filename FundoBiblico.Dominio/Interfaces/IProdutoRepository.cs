using FundoBiblico.Dominio.Entity;

namespace FundoBiblico.Dominio.Interfaces
{
    public interface IProdutoRepository 
    {
        Task<Produto> ObterPorId(Guid id);
        Task Adicionar(Produto produto);
        void Atualizar(Produto produto);
        Task Remover(Produto produto);
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorNome(string? Nome);
    }
}
