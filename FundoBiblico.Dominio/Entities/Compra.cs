using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Entity.EntitysBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Entities
{
    public class Compra : EntityBase
    {
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; private set; }
        public List<Produto> Produtos { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal Troco { get; private set; }


        public void Comprar(Cliente cliente, List<Produto> produtos)
        {
            Cliente = cliente;
            Produtos = produtos;
        }

        public decimal CalculaTroco(decimal valorTotal, decimal valorQueIraPagar)
        {
            return valorQueIraPagar - valorTotal;
        }

    }
}
