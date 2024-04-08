using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Interfaces;
using FundoBiblico.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Repository.Repository
{
    public class CompraRepository : RepositoryBase<Compra>,ICompraRepository
    {
        private readonly FundoBiblicoContext _context;
        public CompraRepository(FundoBiblicoContext fundoBiblico) : base(fundoBiblico)
        {
            _context = fundoBiblico;
        }
    }
}
