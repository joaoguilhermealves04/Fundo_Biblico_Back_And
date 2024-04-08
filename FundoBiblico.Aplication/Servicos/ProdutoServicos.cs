using FundoBiblico.Aplication.Helper;
using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Dominio.Interfaces;
using FundoBiblico.Dominio.Models;
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

        public Task CadastroProduto(ProdutoModel produto)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoModel> ObterProduto(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoModel>> ObterProdutos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
