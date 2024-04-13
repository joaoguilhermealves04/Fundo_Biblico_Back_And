using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Entity.EntitysBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Entity
{
    public class Igreja : EntityBase
    {
        public string Nome { get; private set; }
        public string UF { get; private set; }
        public string Setor { get; private set; }

        public List<Compra> Compras { get; private set; }
        public List<IgrejaProduto> IgrejaProdutos { get; private set; }        

        public Igreja(string nome, string uF, string setor)
        {
            SetNome(nome);
            UF = uF;
            Setor = setor;
        }

        public void AtualizarEntidadeIgreja(string nome, string uF, string setor)
        {
            SetNome(nome);
            UF = uF;
            Setor = setor;
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Por favor! Preencha o nome");

            Nome = nome.ToLower().Trim();
        }
    }
}
