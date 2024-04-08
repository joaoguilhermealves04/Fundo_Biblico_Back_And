using FundoBiblico.Dominio.Entity.EntitysBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Entity
{
    public class Cliente : EntityBase
    {
        public string Nome { get; private set; }
        public int NumeroFilaEspera { get; private set; }

        public Guid IngrejaId { get; set; }
        public Igreja IgrejaPertencente { get; private set; }

        private Cliente(){}

        public Cliente(string nome)
        {
            Nome = nome;
        }
        public Cliente(string nome, Igreja igrejaPertencente)
        {
            SetNome(nome);
            SetIgrejaPertencente(igrejaPertencente);
        }

        public void AtualizarEntidadeCliente(string nome, Igreja igrejaPertencente)
        {
            SetNome(nome);
            SetIgrejaPertencente(igrejaPertencente);
        }

        private void SetNome(string nome)
        {
            if (nome is null)
                throw new ArgumentException("Por favor! Preencha o nome");

            Nome = nome;
        }

        private void SetIgrejaPertencente(Igreja igrejaPertencente)
        {
            if (igrejaPertencente is null)
                throw new ArgumentException("Por favor! Informe a igreja");

            IgrejaPertencente = igrejaPertencente;
        }

        public void ReiniciarNumeroFila() => NumeroFilaEspera = 0;

        public void AtualizarNumeroFilaEspera() => NumeroFilaEspera++;

    }
}
