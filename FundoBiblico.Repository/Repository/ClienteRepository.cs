using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;

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
