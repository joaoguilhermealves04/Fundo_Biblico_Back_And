using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundoBiblicoApi.Controllers
{
    [Route("api/produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoServicos _produtoServicos;
        public ProdutoController(IProdutoServicos produtoServicos)
        {
            _produtoServicos = produtoServicos;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromBody] ProdutoModel produto)
        {
            var produtoCadastar = _produtoServicos.CadastroProduto(produto);
            if (produto == null)
                return BadRequest();

            return NoContent();
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar([FromBody] ProdutoAddEditarModel produtoAddEditar)
        {
            var produtoAtulizar = _produtoServicos.Atualizar(produtoAddEditar);
            if (produtoAtulizar.Exception != null)
                return BadRequest(produtoAtulizar.Exception.ToString());

            return NoContent();
        }


        [HttpGet("get-ALL")]
        public async Task<IActionResult> ObterProdutos()
        {
            var produtos = await _produtoServicos.ObterProdutos();
            if (produtos == null)
                BadRequest();

            return Ok(produtos);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> ObterProduto(Guid id)
        {
            var produto = _produtoServicos.ObterProduto(id);
            if (produto == null)
                BadRequest();

            return Ok(produto.Result);
        }
    }
}
