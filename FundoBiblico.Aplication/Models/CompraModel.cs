using FundoBiblico.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.Models
{
    public class CompraModel
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get;  set; }
        public Cliente Cliente { get;  set; }

        public Guid IgrejaId { get;  set; }
        public Igreja igreja { get;  set; }

        public Guid ProdutoId { get;  set; }
        public Produto Produto { get;  set; }

        public decimal ValorProduto { get;  set; }

        public DateTime DataCompra { get;  set; }

        public int Quantidade { get;  set; }
    }
}
