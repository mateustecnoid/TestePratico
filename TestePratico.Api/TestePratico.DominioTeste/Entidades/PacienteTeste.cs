using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Dominio.Entidades;
using TestePratico.DominioTeste.Builders;
using TestePratico.DominioTeste.Util;
using Xunit;

namespace TestePratico.DominioTeste.Entidades
{
    public class PacienteTeste
    {
        public PacienteTeste()
        {

        }

        [Fact]
        public void DadoPacienteValido_Espero_Paciente_Ser_Criado()
        {
            var pacienteEsperado = new
            {
                Nome = "Teste",
                DataNascimento = new DateTime(1994, 11, 1)
            };

            var paciente = new Paciente(pacienteEsperado.Nome, pacienteEsperado.DataNascimento);

            pacienteEsperado.ToExpectedObject().ShouldMatch(paciente);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Nao_Deve_Paciente_Ter_Nome_Vazio(string nomeVazio)
        {
            Assert.Throws<ArgumentException>(() => PacienteBuilder.Novo().ComNome(nomeVazio).Build()).ComMensagem("Nome não pode ser vazio");
        }

        [Theory]
        [InlineData("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")]
        public void Nao_Deve_Paciente_Ter_Nome_Invalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() => PacienteBuilder.Novo().ComNome(nomeInvalido).Build()).ComMensagem("Nome não pode ter mais que 50 caracteres");
        }
    }
}
