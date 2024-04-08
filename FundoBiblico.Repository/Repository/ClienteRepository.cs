using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;
using FundoBiblico.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Repository.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>,IClienteRepositroy
    {
        private readonly FundoBiblicoContext _context;
        public ClienteRepository( FundoBiblicoContext fundoBiblicoContext) :base(fundoBiblicoContext)
        {
            _context = fundoBiblicoContext;
        }
    }
}
