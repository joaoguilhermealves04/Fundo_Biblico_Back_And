using FundoBiblico.Aplication.Helper;
using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;

namespace FundoBiblico.Aplication.Servicos
{
    public class ProdutoServicos : IProdutoServicos
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ValidacaoDosDadosHelper _vailidar;
        public ProdutoServicos(IProdutoRepository produtoRepository, ValidacaoDosDadosHelper validacaoDosDadosHelper)
        {
            _produtoRepository = produtoRepository;
            _vailidar = validacaoDosDadosHelper;
        }
        public async Task Atualizar(ProdutoAddEditarModel produto)
        {

            try
            {
                var obterProduto = await _produtoRepository.ObterPorId(produto.id);
                if (obterProduto is null)
                    throw new Exception("produto não encontrada");

                obterProduto.AtualizarEntidadeProduto(produto.Nome, produto.Descricao, produto.Foto, produto.Preco,
                    produto.QuantidadeEstoque);

                _produtoRepository.Atualizar(obterProduto);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao fazer atualização do produto.", ex);
            }
        }

        public async Task CadastroProduto(ProdutoAddEditarModel produto)
        {
            try
            {
                var produtoEntity = new Produto(produto.Nome, produto.Descricao, produto.Foto, produto.Preco, produto.QuantidadeEstoque);
                await _produtoRepository.Adicionar(produtoEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar no banco.", ex);
            }
        }

        public async Task<ProdutoModel> ObterProduto(Guid id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentNullException("Id não pode ser nulo.");

                var produto = await _produtoRepository.ObterPorId(id);

                var resultado = new ProdutoModel
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Foto = produto.Foto,
                    Preco = produto.Preco,
                    QuantidadeEstoque = produto.QuantidadeEstoque
                };

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar no banco", ex);
            }

        }

        public async Task<ProdutoModel> ObterProdutoPorNome(string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                    throw new Exception("Por favor Digite um Nome de um produto.");

                var produto = await _produtoRepository.ObterPorNome(nome);

                if (produto == null)
                    throw new Exception("Nenhum produto encontrado com o nome fornecido.");

                return new ProdutoModel
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Foto = produto.Foto,
                    Preco = produto.Preco,
                    QuantidadeEstoque = produto.QuantidadeEstoque,
                };

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro em consultar produtor pelo {nome}", ex);
            }
        }

        public async Task<IEnumerable<ProdutoModel>> ObterProdutos()
        {
            try
            {
                var produtos = await _produtoRepository.ObterTodos();

                var trazerProdutos = new List<ProdutoModel>();

                foreach (var p in produtos)
                {
                    var produtosRetorno = new ProdutoModel
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Descricao = p.Descricao,
                        Foto = p.Foto,
                        Preco = p.Preco,
                        QuantidadeEstoque = p.QuantidadeEstoque,
                    };

                    trazerProdutos.Add(produtosRetorno);
                }

                return trazerProdutos;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar no banco", ex);
            }
        }

        public async Task Remover(Guid id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentNullException("Id não pode ser nulo.");

                var obterProduto = await _produtoRepository.ObterPorId(id);
                if (obterProduto == null)
                {
                    throw new ArgumentNullException("Produto não existe na base de dados");
                }

                await _produtoRepository.Remover(obterProduto);
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possivel remover no banco de dados entre contato com suporte.", ex);
            }
        }
    }
}
