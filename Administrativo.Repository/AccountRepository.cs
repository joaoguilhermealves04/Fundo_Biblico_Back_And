using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task Login(Usuario usuario)
        {
            await signInManager.PasswordSignInAsync(usuario.NomeUsuario,usuario.PassWord,false,false);
            
        }

        public async Task Registrar(Usuario usuario)
        {
            var user = new IdentityUser
            {
                UserName = usuario.NomeUsuario,
                Email = usuario.Email
            };
           var result = await _userManager.CreateAsync(user, usuario.PassWord);

            if(result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
            }
        }
    }
}
