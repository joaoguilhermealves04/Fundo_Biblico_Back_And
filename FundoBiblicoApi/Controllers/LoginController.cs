using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FundoBiblicoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountServicos _accountServicos;

        public LoginController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IAccountServicos accountServicos)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _accountServicos = accountServicos;
        }

        [HttpPost ("Registrar")]
        public async Task <IActionResult> Registrar([FromBody]RegistrarUsuario user)
        {
            if (ModelState.IsValid)
            {
               var result = _accountServicos.registre(user);

                if (result.IsCompletedSuccessfully)
                    return Ok("Cadastro Realizado Com Sucesso!");
            }
            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginUsuario login)
        {
            if (ModelState.IsValid)
            {
                var result = _accountServicos.Login(login);
                if (result.IsCompletedSuccessfully)
                {
                   return Ok(result.ToString());
                }
            }

            return BadRequest();
        }

    
    }
}
