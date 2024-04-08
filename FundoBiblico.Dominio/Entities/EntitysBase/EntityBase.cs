using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Entity.EntitysBase
{
    public class EntityBase
    {
        public Guid Id { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public EntityBase()
        {
            DataCadastro = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
