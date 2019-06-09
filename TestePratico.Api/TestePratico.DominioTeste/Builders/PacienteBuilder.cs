using System;
using TestePratico.Dominio.Entidades;

namespace TestePratico.DominioTeste.Builders
{
    public class PacienteBuilder
    {
        private string Nome = "Mateus Candido";
        private DateTime DataNascimento = new DateTime(1994, 11, 1);

        public static PacienteBuilder Novo()
        {
            return new PacienteBuilder();
        }

        public PacienteBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public PacienteBuilder ComDataNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
            return this;
        }

        public Paciente Build()
        {
            return new Paciente(Nome, DataNascimento);
        }
    }
}
