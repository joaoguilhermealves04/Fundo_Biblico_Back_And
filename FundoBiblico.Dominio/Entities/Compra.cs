using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Entity.EntitysBase;


namespace FundoBiblico.Dominio.Entities
{
    public class Compra : EntityBase
    {
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }

        public Guid IgrejaId { get; private set; }
        public Igreja igreja { get; private set; }

        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }

        public decimal ValorProduto { get; private set; }

        public DateTime DataCompra { get; private set; }

        public int Quantidade { get; private set; }

        private Compra() { }

        public Compra(Guid clienteId, Guid igrejaId, Guid produtoId, decimal valorProduto, int quantidade)
        {
            ClienteId = clienteId;
            IgrejaId = igrejaId;
            ProdutoId = produtoId;
            ValorProduto = valorProduto;
            Quantidade = quantidade;
            DataCompra = DateTime.Now;
        }

    }
}
