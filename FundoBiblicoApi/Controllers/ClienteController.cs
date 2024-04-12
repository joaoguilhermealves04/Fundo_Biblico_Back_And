using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Dominio.Models;
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
        public IActionResult Cadastrar(ClienteAddEditarModel cliente)
        {
            var clienteCadastrar = _clienteServicos.CadastroCliente(cliente);

            if(clienteCadastrar.Exception != null)
                return BadRequest(clienteCadastrar.Exception);

            return NoContent();
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(ClienteAddEditarModel cliente)
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
        public IActionResult ObterCliente(Guid id)
        {
            var ObterCliente = _clienteServicos.ObterCliente(id);

            if (ObterCliente.Exception != null)
                return BadRequest(ObterCliente.Exception);

            return Ok(ObterCliente.Result);
        }
    }
}
