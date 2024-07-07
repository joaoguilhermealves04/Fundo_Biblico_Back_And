using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Entities
{
    public class Usuario
    {
        public string NomeUsuario { get;private set; }
        public string PassWord { get;private set; }
        public string Email { get; set; }

        public void login (string username, string password)
        {
            SetUsuarioNome(NomeUsuario);
            PassWord = PassWord;
        }

        public void Registre (string username, string password,string email)
        {
            SetUsuarioNome(NomeUsuario);
            PassWord = PassWord;
            Email = email;
        }

        public void SetUsuarioNome(string nomeusuario)
        {
            if (string.IsNullOrEmpty(nomeusuario))
                throw new ArgumentException("Por favor! Preencha o nome");

            NomeUsuario = nomeusuario.ToLower().Trim();
        }
    }
}
