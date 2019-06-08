using System;

namespace TestePratico.Dominio.Entidades
{
    public class Paciente
    {
        public int Codigo { get; protected set; }
        public string Nome { get; protected set; }
        public DateTime DataNascimento { get; protected set; }

        protected Paciente() { }

        public Paciente(string nome, DateTime dataNascimento)
        {
            SetNome(nome);
            SetDataNascimento(dataNascimento);
        }


        public void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome não pode ser vazio");
            }

            if (nome.Length > 50)
            {
                throw new ArgumentException("Nome não pode ter mais que 50 caracteres");
            }

            Nome = nome;
        }

        public void SetDataNascimento(DateTime dataNascimento)
        {
            if(dataNascimento == new DateTime())
            {
                throw new AggregateException("A data deve ser valida");
            }

            DataNascimento = dataNascimento;
        }
    }
}
