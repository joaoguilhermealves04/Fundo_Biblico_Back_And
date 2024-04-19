using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Entity.EntitysBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Entities
{
    public class IgrejaProduto : EntityBase
    {
        public Guid IgrejaId { get; set; }
        public Igreja Igreja { get; set; }

        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade{ get; set; }

        public IgrejaProduto(Guid igrejaId,Guid produtoId,int quantidade)
        {
            IgrejaId = igrejaId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }
    }
}
