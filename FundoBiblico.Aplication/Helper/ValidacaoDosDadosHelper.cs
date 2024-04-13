

namespace FundoBiblico.Aplication.Helper
{
    public  class ValidacaoDosDadosHelper
    {
        private readonly FundoBiblicoContext _biblicoContext;
        public ValidacaoDosDadosHelper(FundoBiblicoContext fundoBiblico)
        {
            _biblicoContext = fundoBiblico;
        }

        public bool IgrejaExiste(string nome)
        {
            var igrejaexiste = _biblicoContext.Igrejas.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
            if (igrejaexiste != null)
            {
                return true;
            }
            return false;
        }
    }
}
