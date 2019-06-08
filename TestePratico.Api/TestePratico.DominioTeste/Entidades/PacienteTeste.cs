using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Dominio.Entidades;
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

    }
}
