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
        public string Foto { get; private set; }
        public double Preco { get; private set; }
        public int QuantidadeEstoque { get;private set; }

        private Produto() { } // Construtor privado para evitar criação sem parâmetros

        public Produto(string nome, string descricao, string foto, double preco, int quantidadeEstoque)
        {
            Nome = nome;
            Descricao = descricao;
            Foto = foto;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public void AtualizarEntidadeProduto(string nome, string descricao,string foto, double preco, int quantidadeEstoque)
        {
            SetNome(nome);
            Descricao = descricao;
            Foto = foto;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }


        public void SetNome(string nome) => Nome = nome != null ? nome.ToLower().Trim() : "";

    }
}
