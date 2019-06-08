using System;

namespace TestePratico.Dominio.Entidades
{
    public class Agendamento
    {
        public int Codigo { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataInicial { get; protected set; }
        public DateTime DataFinal { get; protected set; }
        public string Observacao { get; protected set; }

        protected Agendamento() { }

        public Agendamento(Paciente paciente, DateTime dataInicial, DateTime dataFinal, string observacao)
        {
            SetPaciente(paciente);
            SetDataConsulta(dataInicial, dataFinal);
            SetObservacao(observacao);
        }

        public void SetPaciente(Paciente paciente)
        {
            if(paciente == null)
            {
                throw new ArgumentException("Paciente deve ser valido");
            }

            Paciente = paciente;
        }

        public void SetDataConsulta(DateTime dataInicio, DateTime dataFim)
        {
            if(dataInicio == new DateTime())
            {
                throw new ArgumentException("Data inicial não pode ser nula");
            }

            if (dataFim == new DateTime())
            {
                throw new ArgumentException("Data final não pode ser nula");
            }

            if (dataFim < dataInicio)
            {
                throw new ArgumentException("Data Final menor que a data inicial");
            }

            DataInicial = dataInicio;
            DataFinal = dataFim;
        }

        public void SetObservacao(string observacao)
        {
            if(!string.IsNullOrEmpty(observacao) && observacao.Length > 500)
            {
                throw new ArgumentException("Tamanho da observação não deve ser maior que 500 caracteres");
            }

            Observacao = observacao;
        }
    }
}
