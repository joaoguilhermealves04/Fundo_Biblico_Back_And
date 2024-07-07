using FundoBiblico.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.IServicos
{
    public interface IAccountServicos
    {
        Task registre(RegistrarUsuario registrar);
        Task Login(LoginUsuario login);
    }
}
