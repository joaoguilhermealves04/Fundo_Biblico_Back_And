using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Interfaces;

namespace FundoBiblico.Aplication.Servicos
{
    public class IgrejaProdutoServices : IIgrejaProdutoServices
    {
        private readonly IIgrejaProdutoRepository _igrejaProdutoRepository;
        public IgrejaProdutoServices(IIgrejaProdutoRepository igrejaProdutoRepository)
        {
            _igrejaProdutoRepository = igrejaProdutoRepository;
        }

        public Task Atualizar(IgrejaProdutoAddEditarModel igrejaProduto)
        {
            try
            {
                if (igrejaProduto == null)
                    throw new ArgumentNullException(nameof(igrejaProduto), "Por favor preencha corretamente.");

                var Resultado =  _igrejaProdutoRepository.ObterPorId(igrejaProduto.Id);

                if (Resultado == null)
                    throw new NotFiniteNumberException("IgrejaProduto Não encontrado.");

                Resultado.Result.Quantidade = igrejaProduto.Quantidade;

                _igrejaProdutoRepository.Atualizar(Resultado.Result);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw new Exception("O correu erro ao atualizar.",ex);
            }


        }

        public async Task CadastroIgrejaProduto(IgrejaProdutoAddEditarModel igrejaProduto)
        {
            try
            {
                if (igrejaProduto == null) 
                    throw new ArgumentNullException("Por favor Preenchar corretamente.");

                var cadastra = new IgrejaProduto(igrejaProduto.ProdutoId, igrejaProduto.IgrejaId, igrejaProduto.Quantidade);
                await _igrejaProdutoRepository.Adicionar(cadastra);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao adicionar.",ex);
            }
        }

        public async Task<IgrejaProdutoModel> ObterIgrejaProduto(Guid? id)
        {
            try
            {
                if(id == null) 
                    throw new ArgumentNullException("id não pode ser null");

                var resposta = await _igrejaProdutoRepository.ObterPorId(id.Value);
                var resultado = new IgrejaProdutoModel 
                { 
                    ProdutoId = resposta.ProdutoId,
                    Produto = resposta.Produto,
                    IgrejaId= resposta.IgrejaId,
                    Quantidade = resposta.Quantidade
                };

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao busca o produtos da igreja referenciada.",ex);
            }
        }

        public async Task<IEnumerable<IgrejaProdutoModel>> ObterIgrejasProduto()
        {
            try
            {
                var resposta = await _igrejaProdutoRepository.ObterTodos();

                if (resposta == null)
                    throw new ArgumentException("Não foi encontrado ou teve um erro na consulta");

                var resultado = new List<IgrejaProdutoModel>();
                foreach (var Ip in resultado)
                {
                    var igrejaProdutoModal = new IgrejaProdutoModel
                    {
                        IgrejaId = Ip.IgrejaId,
                        Igreja =Ip.Igreja,
                        ProdutoId =Ip.ProdutoId,
                        Produto= Ip.Produto,
                        Quantidade=Ip.Quantidade
                    };
                    resultado.Add(igrejaProdutoModal);
                }

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception ("Erro ao consultar produtos da igreja referenciada.",ex);
            }
        }

        public Task RemoverIgrejaProduto(Guid id)
        {
            try
            {
                if(id == null)
                    throw new ArgumentNullException("id não pode ser nullo");

                var igrejaProduto = _igrejaProdutoRepository.ObterPorId(id);

                _igrejaProdutoRepository.Remover(igrejaProduto.Result);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir.",ex);
            }
        }
    }
}
