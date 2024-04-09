using FundoBiblico.Aplication.Helper;
using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;
using FundoBiblico.Dominio.Models;
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
        public Task Atualizar(ProdutoAddEditarModel produto)
        {
            throw new NotImplementedException();
        }

        public async Task CadastroProduto(ProdutoModel produto)
        {
            try
            {
                var validarIgreja = _vailidar.IgrejaExiste(produto.IgrejaPertencente.Nome);
                if (validarIgreja == false)
                {
                    throw new Exception("Igreja não encontrada na base de Dados.");
                }

                var produtoEntity = new Produto(produto.Nome, produto.Descricao, produto.Preco, produto.QuantidadeEstoque);
                await _produtoRepository.Adicionar(produtoEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar no banco.", ex);
            }
        }

        public async Task<ProdutoModel> ObterProduto(Guid? id)
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
                    Preco = produto.Preco,
                    QuantidadeEstoque = produto.QuantidadeEstoque,
                    IgrejaPertencente = produto.IgrejaPertencente
                };

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar no banco",ex);
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
                        IgrejaPertencente = p.IgrejaPertencente
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

        public Task Remover(Guid? id)
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
