using FluentAssertions;
using FundoBiblico.Dominio.Entity;

namespace FundoBiblico.Test.Dominio
{
    public class IgrejaDominioTest
    {
        [Fact(DisplayName = "Adicionar igreja campos válidos")]
        public void AdicionarIgreja_CamposVálidos_DeveRetornarSucesso()
        {
            //Arrange
            string nome = "jd maravilha";
            string uf = "RJ";
            string setor = "1";

            //Act
            var igreja = new Igreja(nome, uf, setor);

            //Assert
            igreja.Nome.Should().Be(nome);
            igreja.UF.Should().Be(uf);
            igreja.Setor.Should().Be(setor);
        }

        [Fact(DisplayName = "Adicionar igreja campos UF e Setor vazio")]
        public void AdicionarIgreja_CamposUFESetorVazio_DeveRetornarSucesso()
        {
            //Arrange
            string nome = "jd maravilha";
            string uf = string.Empty;
            string setor = string.Empty;

            //Act
            var igreja = new Igreja(nome, uf, setor);

            //Assert
            igreja.Nome.Should().Be(nome);
            igreja.UF.Should().BeNullOrEmpty();
            igreja.Setor.Should().BeNullOrEmpty();
        }

        [Fact(DisplayName = "Adicionar igreja campo nome vazio")]
        public void AdicionarIgreja_CampoNomeVazio_DeveRetornarErro()
        {
            //Arrange
            string nome = "";
            string uf = "RJ";
            string setor = "1";

            //Act
            Action act = () => new Igreja(nome, uf, setor);

            //Assert
            act.Should().Throw<Exception>()
              .WithMessage("Por favor! Preencha o nome");
        }

        [Fact(DisplayName = "Atualizar igreja campos válidos")]
        public void AtualizarIgreja_CamposValidos_DeveRetornarSucesso()
        {
            //Arrange
            string nomeAntigo = "jd maravilha";
            string ufAntigo = "RJ";
            string setorAntigo = "1";

            string nomeNovo = "carius";
            string ufNovo = "ES";
            string setorNovo = "3";

            //Act
            var igreja = new Igreja(nomeAntigo, ufAntigo, setorAntigo);

            igreja.AtualizarEntidadeIgreja(nomeNovo, ufNovo, setorNovo);

            //Assert
            igreja.Nome.Should().Be(nomeNovo);
            igreja.UF.Should().Be(ufNovo);
            igreja.Setor.Should().Be(setorNovo);
        }

        [Fact(DisplayName = "Atualizar igreja campo nome vazio")]
        public void AtualizarIgreja_CampoNomeVazio_DeveRetornarErro()
        {
            //Arrange
            string nomeAntigo = "jd maravilha";
            string ufAntigo = "RJ";
            string setorAntigo = "1";

            string nomeNovo = string.Empty;
            string ufNovo = "ES";
            string setorNovo = "3";

            //Act
            var igreja = new Igreja(nomeAntigo, ufAntigo, setorAntigo);

            //Act
            Action act = () =>
            igreja.AtualizarEntidadeIgreja(nomeNovo, ufNovo, setorNovo);

            //Assert
            act.Should().Throw<Exception>()
              .WithMessage("Por favor! Preencha o nome");
        }
    }
}
