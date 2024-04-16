using FundoBiblico.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.Models
{
    public class ProdutoAddEditarModel
    {
        public Guid id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get;set; }
        public string Foto { get; set; }
        public decimal Preco { get;  set; }
        public int QuantidadeEstoque { get; set; }
    }
}
