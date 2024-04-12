using FundoBiblico.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Models
{
    public class ProdutoModel
    {
        public Guid Id { get; set; }
        [MaxLength(15)]
        public string Nome { get; set; }
        [MaxLength(150)]
        public string Descricao { get;  set; }
        public decimal Preco { get;  set; }
        public int QuantidadeEstoque { get;  set; }
    }
}
