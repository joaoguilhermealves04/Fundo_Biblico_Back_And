using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundoBiblicoApi.Controllers
{
    [Route("api/compra")]
    public class CompraController : Controller
    {
        private readonly ICompraServices _services;
        public CompraController(ICompraServices services)
        {
            _services = services;
        }

        [HttpPost("Adicionar")]
        public IActionResult Adicionar([FromBody] CompraEditarAddModel compra)
        {

            if (compra == null)
                throw new ArgumentNullException("Preenche o campos corretamente");

            var compraRealizada = _services.CadastroCompra(compra);

            if(compraRealizada.Exception != null)
                throw compraRealizada.Exception;

            return NoContent();
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar([FromBody] CompraEditarAddModel compra)
        {
            if (compra == null)
                throw new ArgumentNullException("Preenche os Campos corretamente!");

            var compraAtualizar = _services.Atualizar(compra);

            if(compraAtualizar.Exception != null)
                throw compraAtualizar.Exception;

            return NoContent();
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> ObterCompras()
        {
            var compras = await _services.ObterCompras();

            if (compras == null)
                throw new ArgumentNullException("Compras não encontrada");

            return Ok(compras);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> obterCompra(Guid id)
        {
            var compra = await _services.ObterCompra(id);

            if (compra == null)
                throw new ArgumentNullException("Compra não encontrada");

            return Ok(compra);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult remover(Guid id)
        {
            var removerCompra = _services.Remover(id);

            if(removerCompra.Exception !=null)
                throw removerCompra.Exception;

            return NoContent();
        }

    }
}
