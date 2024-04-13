using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.Models
{
    public class IgrejaModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string Setor { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
