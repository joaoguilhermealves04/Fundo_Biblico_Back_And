using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Entity.EntitysBase;

namespace FundoBiblico.Dominio.Entity
{
    public class Cliente : EntityBase
    {
        public string Nome { get; private set; }

        public List<Compra> Compras { get; private set; }

        private Cliente(){}

        public Cliente(string nome)
        {
            SetNome(nome);
        }

        public void AtualizarEntidadeCliente(string nome)
        {
            SetNome(nome);
        }

        private void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("Por favor! Preencha o nome");

            Nome = nome;
        }
    }
}
