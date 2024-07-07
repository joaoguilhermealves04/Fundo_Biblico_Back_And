using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.Servicos
{
    public class AccountServicos : IAccountServicos
    {
        private readonly IAccountRepository _accountRepository;

        public AccountServicos(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task Login(LoginUsuario login)
        {
            try
            {
                var usuario = new Usuario();

                usuario.login(login.NomeUsuario, login.Password);

                await _accountRepository.Login(usuario);
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu o seguinte erro ", ex);
            }
        }

        public async Task registre(RegistrarUsuario registrar)
        {
            try
            {
                var usuarioNovo = new Usuario();

                usuarioNovo.Registre(registrar.NomeUsuario, registrar.Password, registrar.Email);

                await _accountRepository.Registrar(usuarioNovo);
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao registrar um usuario. " ,ex);
            }

        }


    }
}
