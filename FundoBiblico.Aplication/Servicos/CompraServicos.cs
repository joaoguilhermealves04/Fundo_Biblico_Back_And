using FundoBiblico.Aplication.Helper;
using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.Servicos
{
    public class CompraServicos : ICompraServices
    {
        private readonly ICompraRepository _compraRepository;
        private readonly ValidacaoDosDadosHelper _validacaoDosDadosHelper;
        public CompraServicos(ICompraRepository compraRepository, ValidacaoDosDadosHelper validacaoDosDadosHelper)
        {
            _compraRepository = compraRepository;
            _validacaoDosDadosHelper = validacaoDosDadosHelper;
        }

        public Task Atualizar(CompraEditarAddModel compra)
        {
            var validarIgreja = _validacaoDosDadosHelper.IgrejaExiste(compra.igreja.Nome) ? true : false;
            if (!validarIgreja)
                throw new ArgumentException("Igreja não encontrada na nossa base de dados");

            var inseriCompra = new Compra(compra.ClienteId, compra.IgrejaId, compra.ProdutoId, compra.ValorProduto, compra.Quantidade);
             _compraRepository.Atualizar(inseriCompra);

            return Task.CompletedTask;
        }

        public async Task CadastroCompra(CompraModel compra)
        {
            try
            {
                if (compra is null)
                    throw new ArgumentNullException("A propriedade não pode se nula pode preencher corretamente");

                var validarIgreja = _validacaoDosDadosHelper.IgrejaExiste(compra.igreja.Nome) ? true : false;
                if (!validarIgreja)
                    throw new ArgumentException("Igreja não encontrada na nossa base de dados");


                var inseriCompra = new Compra(compra.ClienteId, compra.IgrejaId, compra.ProdutoId, compra.ValorProduto, compra.Quantidade);
                await _compraRepository.Adicionar(inseriCompra);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir Compra. Por favor tente mais tarde novamente.", ex);
            }
        }

        public async Task<IEnumerable<CompraModel>> ObterCompra()
        {
            try
            {
                var obterCompras = await _compraRepository.ObterTodos();

                if (obterCompras == null)
                    throw new ArgumentException("Nemhuma Compra Foi encontrada na base de Dados ");

                var resultado = new List<CompraModel>();
                foreach (var c in obterCompras)
                {
                    var compraModel = new CompraModel
                    {
                        Id = c.Id,
                        ClienteId = c.ClienteId,
                        IgrejaId= c.IgrejaId,
                        ProdutoId = c.ProdutoId,
                        Quantidade = c.Quantidade,
                        ValorProduto = c.ValorProduto,
                        DataCompra = c.DataCompra,
                    };

                    resultado.Add(compraModel);
                }
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar Compra no banco",ex);
            }
        }

        public async Task<CompraModel> ObterCompra(Guid id)
        {
            try
            {
                if(id == null)
                    throw new ArgumentNullException("Id não pode ser nulo por favor informe um Id.");

                var compra = await _compraRepository.ObterPorId(id);
                var compraModel = new CompraModel
                {
                    Id = compra.Id,
                    ClienteId = compra.ClienteId,
                    IgrejaId = compra.IgrejaId,
                    ProdutoId = compra.ProdutoId,
                    Quantidade = compra.Quantidade,
                    ValorProduto = compra.ValorProduto,
                    DataCompra = compra.DataCompra,
                };

                return compraModel;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao obter compra.",ex);
            }
        }

        public Task Remover(Guid id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentNullException("Id não pode ser nulo por favor informe um Id.");

                var compra = _compraRepository.ObterPorId(id);
                _compraRepository.Remover(compra.Result);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel remover a compra.",ex);
            }
        }
    }
}
