using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundoBiblicoApi.Controllers
{
    [Route("api/cliente")]
    public class ClienteController : Controller
    {
        private readonly IClienteServicos _clienteServicos;
        public ClienteController(IClienteServicos clienteServicos)
        {
            _clienteServicos = clienteServicos;
        }

        [HttpPost("Cadastar")]
        public IActionResult Cadastrar([FromBody] ClienteAddEditarModel cliente)
        {
            var clienteCadastrar = _clienteServicos.CadastroCliente(cliente);

            if(clienteCadastrar.Exception != null)
                return BadRequest(clienteCadastrar.Exception);

            return NoContent();
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar([FromBody] ClienteAddEditarModel cliente)
        {
            var clienteAtualizar = _clienteServicos.AtualizarCliente(cliente);

            if (clienteAtualizar.Exception != null)
                return BadRequest(clienteAtualizar.Exception);

            return NoContent();
        }

        [HttpGet("get-all")]
        public async Task <IActionResult> ObterClientes()
        {
            var obterTodosClientes = await _clienteServicos.ObterClientes();

            if (obterTodosClientes == null)
                return BadRequest();

            return Ok(obterTodosClientes);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> ObterCliente(Guid id)
        {
            var obterCliente = await _clienteServicos.ObterCliente(id);

            if (obterCliente == null)
                return BadRequest();

            return Ok(obterCliente);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> RemoverCliente(Guid id)
        {
            var resutado = _clienteServicos.Remover(id);

            if(resutado.Exception != null)
                return Ok(resutado.Exception);

            return NoContent();
        }
    }
}
