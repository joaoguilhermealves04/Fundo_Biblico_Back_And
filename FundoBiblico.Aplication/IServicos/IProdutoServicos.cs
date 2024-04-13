using FundoBiblico.Aplication.Models;


namespace FundoBiblico.Aplication.IServicos
{
    public interface IProdutoServicos
    {
        Task CadastroProduto(ProdutoModel produto);
        Task Atualizar(ProdutoAddEditarModel produto);
        Task<IEnumerable<ProdutoModel>> ObterProdutos();
        Task<ProdutoModel> ObterProduto(Guid id);
        Task Remover(Guid id);
        Task<ProdutoModel> ObterProdutoPorNome(string nome);
    }
}
