using FundoBiblico.Aplication.Helper;
using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;
using FundoBiblico.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var obterProduto =  _produtoRepository.ObterPorId(produto.id);
                if (obterProduto is null)
                    throw new Exception("produto não encontrada");

                obterProduto.Result.AtualizarEntidadeProduto(produto.Nome, produto.Descricao,produto.Foto ,produto.Preco, 
                    produto.QuantidadeEstoque);

                _produtoRepository.Atualizar(obterProduto.Result);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao fazer atualização do produto.",ex);
            }
        }

        public async Task CadastroProduto(ProdutoModel produto)
        {
            try
            {
                var produtoEntity = new Produto(produto.Nome, produto.Descricao,produto.Foto,produto.Preco, produto.QuantidadeEstoque);
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

                var produto =  _produtoRepository.ObterPorId(id);

                var resultado = new ProdutoModel
                {
                    Id = produto.Result.Id,
                    Nome = produto.Result.Nome,
                    Descricao = produto.Result.Descricao,
                    Preco = produto.Result.Preco,
                    QuantidadeEstoque = produto.Result.QuantidadeEstoque
                };

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar no banco",ex);
            }

        }

        public async Task<ProdutoModel> ObterProdutoPorNome(string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                {
                    throw new Exception("Por favor Digite um Nome de um produto.");
                }

                var produto = await _produtoRepository.ObterPorNome(nome);

                if (produto == null)
                {
                    throw new Exception("Nenhum produto encontrado com o nome fornecido.");
                }

                return  new ProdutoModel
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    QuantidadeEstoque = produto.QuantidadeEstoque,
                };

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro em consultar produtor pelo {nome}",ex);
            }
        }

        public async Task<IEnumerable<ProdutoModel>> ObterProdutos()
        {
            try
            {
                var produtos = await _produtoRepository.ObterTodos();

                var trazerProdutos = new List<ProdutoModel>();

                foreach (var p in produtos )
                {
                    var produtosRetorno = new ProdutoModel
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Descricao = p.Descricao,
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

        public Task Remover(Guid id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentNullException("Id não pode ser nulo.");

                var obterProduto =  _produtoRepository.ObterPorId(id);
                if(obterProduto.Result == null)
                {
                    throw new ArgumentNullException("Produto não existe na base de dados");
                }

                _produtoRepository.Remover(obterProduto.Result);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possivel remover no banco de dados entre contato com suporte.",ex);
            }
        }
    }
}
