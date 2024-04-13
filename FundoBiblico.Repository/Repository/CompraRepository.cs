using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Interfaces;

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
