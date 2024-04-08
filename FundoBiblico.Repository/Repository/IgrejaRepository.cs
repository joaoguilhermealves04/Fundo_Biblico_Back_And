using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;
using FundoBiblico.Repository.Data;

namespace FundoBiblico.Repository.Repository
{
    public class IgrejaRepository : RepositoryBase<Igreja>, IIgrejaRepository
    {
        private readonly FundoBiblicoContext _context;
        public IgrejaRepository(FundoBiblicoContext fundoBiblicoContext):base(fundoBiblicoContext) 
        {
            _context = fundoBiblicoContext;
        }
    }
}
