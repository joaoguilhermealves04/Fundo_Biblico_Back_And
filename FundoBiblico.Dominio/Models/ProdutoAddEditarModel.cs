using FundoBiblico.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Models
{
    public class ProdutoAddEditarModel
    {
        public Guid id { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
    }
}
