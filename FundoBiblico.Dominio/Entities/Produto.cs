using FundoBiblico.Dominio.Entity.EntitysBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Entity
{
    public class Produto : EntityBase
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get;private set; }
        public Guid IgrejaPertencenteId { get; private set; } // Chave estrangeira para a igreja pertencente
        public Igreja IgrejaPertencente { get; private set; }

        private Produto() { } // Construtor privado para evitar criação sem parâmetros

        public Produto(string nome, string descricao, decimal preco, int quantidadeEstoque)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }


    }
}
