using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Repository.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Task Login(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task Registrar(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
