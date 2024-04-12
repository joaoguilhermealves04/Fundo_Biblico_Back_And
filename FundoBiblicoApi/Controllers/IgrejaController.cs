using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Dominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundoBiblicoApi.Controllers
{
    [Route("api/igreja")]
    public class IgrejaController : Controller
    {
        private readonly IIgrejaServicos _igrejaServicos;
        public IgrejaController(IIgrejaServicos igrejaServicos)
        {
            _igrejaServicos = igrejaServicos;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> ObterTodos()
        {
            var resultatdo = await _igrejaServicos.ObterIgrejas();
            if (resultatdo == null)
            {
                return BadRequest();
            }
            return Ok(resultatdo.ToList());
        }

        [HttpPost("Adicionar")]
        public IActionResult AdicionarIgreja(IgrejaAddEditarModel igrejaAddEditar)
        {
            var igreja = _igrejaServicos.CadastroIgreja(igrejaAddEditar);
            if (igreja.Exception != null)
            {
                return Ok(igreja.Exception.ToString());
            }

            return NoContent();
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(IgrejaAddEditarModel igrejaAddEditar)
        {
            var igreja = _igrejaServicos.Atualizar(igrejaAddEditar);
            if (igreja.Exception != null)
            {
                return Ok(igreja.Exception.ToString());
            }

            return NoContent();
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> ObterUmaIgreja(Guid id)
        {
            var resultatdo = await _igrejaServicos.ObterIgreja(id);
            if (resultatdo == null)
            {
                return BadRequest();
            }
            return Ok(resultatdo);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            if (id == null)
            {
                return BadRequest("O id não pode ser nulo.");
            }
            var resultado= _igrejaServicos.Remover(id);

            if(resultado.Exception != null)
            {
                return Ok(resultado.Exception.ToString());
            }

           return NoContent();
        }

    }
}
