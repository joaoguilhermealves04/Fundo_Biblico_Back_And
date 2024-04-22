using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FundoBiblicoApi.Controllers
{
    [Route("api/IgrejaProduto")]
    public class IgrejaProdutoController : Controller
    {
        private readonly IIgrejaProdutoServices _services;
        public IgrejaProdutoController(IIgrejaProdutoServices services)
        {
            _services = services;
        }

        [HttpPost("Adiconar")]
        public IActionResult Adicionar([FromBody] IgrejaProdutoAddEditarModel igrejaProduto)
        {
            if (igrejaProduto == null)
                throw new ArgumentNullException("Preenche o campos corretamente");

            var adicinonar = _services.CadastroIgrejaProduto(igrejaProduto);

            if (adicinonar.Exception != null)
                throw adicinonar.Exception;

            return NoContent();
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar([FromBody] IgrejaProdutoAddEditarModel igrejaProduto)
        {

            if (igrejaProduto == null)
                throw new ArgumentNullException("Preenche o campos corretamente");

            var atualizar = _services.Atualizar(igrejaProduto);

            if (atualizar.Exception != null) throw atualizar.Exception;

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Remover(Guid id)
        {
            var remover = _services.RemoverIgrejaProduto(id);

            if (remover.Exception != null) throw remover.Exception;

            return NoContent();
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> ObterIgrejaProdutos()
        {
            var resultado = await _services.ObterIgrejasProduto();

            if (resultado.IsNullOrEmpty())
                return BadRequest("Produtos não encontrados");

            return Ok(resultado);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> ObterIgrejaProduto(Guid id)
        {
            var resultado = await _services.ObterIgrejaProduto(id);

            if (resultado == null)
                return BadRequest("Produtos não encontrados");

            return Ok(resultado);

        }
    }
}
