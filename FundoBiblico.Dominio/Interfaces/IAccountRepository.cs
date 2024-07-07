using FundoBiblico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Interfaces
{
    public interface IAccountRepository
    {
        Task Registrar(Usuario usuario);
        Task Login(Usuario usuario);
    }
}
