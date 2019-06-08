using System;

namespace TestePratico.DataTransfer.Request
{
    public class AgendamentoRequest
    {
        public int Codigo { get; set; }
        public int CodigoPaciente { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Observacao { get;  set; }
    }
}
