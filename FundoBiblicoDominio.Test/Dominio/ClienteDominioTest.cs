using FluentAssertions;
using FundoBiblico.Dominio.Entity;
using System;


namespace FundoBiblico.Test.Dominio
{
    public class ClienteDominioTest
    {

        [Fact(DisplayName = "Adicionar cliente campos válidos")]
        public void AdicionarCliente_CamposVálidos_DeveRetornarSucesso()
        {
            //Arrange
            string nome = "RafaelTeste";

            //Act
            var cliente = new Cliente(nome);

            //Assert

            cliente.Nome.Should().Be(nome);
        }

        [Fact(DisplayName = "Adicionar cliente campos inválidos")]
        public void AdicionarCliente_CamposInvalidos_DeveRetornarErro()
        {
            //Arrange
            string nome = "";

            //Act
            Action act = () => new Cliente(nome);

            //Assert
            act.Should().Throw<Exception>()
              .WithMessage("Por favor! Preencha o nome");
        }

        [Fact(DisplayName = "Atualizar cliente campos válidos")]
        public void AtualizarCliente_CamposVálidos_DeveRetornarSucesso()
        {
            //Arrange
            string nomeAntigo = "RafaelAntigo";
            string nomeNovo = "RafaelNovo";

            //Act
            var cliente = new Cliente(nomeAntigo);
            cliente.AtualizarEntidadeCliente(nomeNovo);

            //Assert

            cliente.Nome.Should().Be(nomeNovo);
        }

        [Fact(DisplayName = "Atualizar cliente campos vazio")]
        public void AtualizarCliente_CamposVazio_DeveRetornarErro()
        {
            //Arrange
            string nomeAntigo = "RafaelAntigo";
            string nomeNovo = string.Empty;

            //Act
            var cliente = new Cliente(nomeAntigo);
            Action act = () => cliente.AtualizarEntidadeCliente(nomeNovo);

            //Assert
            act.Should().Throw<Exception>()
              .WithMessage("Por favor! Preencha o nome");
        }
    }
}
