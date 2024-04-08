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
    public class Compra :EntityBase
    {
        public Cliente Cliente { get;private set; }
        public List<Produto> Produtos { get;private set; }
        public Double ValorTotal { get; private set; }
        public Double Troco { get; private set; }


        public void Comprar(Cliente cliente, List<Produto> produtos)
        {
            Cliente = cliente;
            Produtos= produtos;
        }

        public double CalculaTroco(double valorTotal, double valorQueIraPagar)
        {
            double troco = valorQueIraPagar - valorTotal;
            return troco;
        }

    }
}
