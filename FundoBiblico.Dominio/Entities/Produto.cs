using FundoBiblico.Dominio.Entities;
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
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get;private set; }

        public List<Compra> Compras { get; private set; }
        public List<IgrejaProduto> IgrejaProdutos { get; private set; }

        private Produto() { }

        public Produto(string nome, string descricao, string foto, decimal preco, int quantidadeEstoque)
        {
            Nome = nome;
            Descricao = descricao;
            Foto = foto;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public void AtualizarEntidadeProduto(string nome, string descricao,string foto, decimal preco, int quantidadeEstoque)
        {
            SetNome(nome);
            Descricao = descricao;
            Foto = foto;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }


        public void SetNome(string nome) =>  Nome = 
            !string.IsNullOrEmpty(nome) ? nome.ToLower().Trim() : "";

        public void AdicionarQuantidadeEmEstoque(int quantidade) => QuantidadeEstoque += quantidade;

        public void RemoverQuantidadeEmEstoque(int quantidade) => QuantidadeEstoque += quantidade;

    }
}
