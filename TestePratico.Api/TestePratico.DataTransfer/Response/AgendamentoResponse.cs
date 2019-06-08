using System;
using System.Collections.Generic;
using System.Text;

namespace TestePratico.DataTransfer.Response
{
    public class AgendamentoResponse
    {
        public int Codigo { get; set; }
        public PacienteResponse Paciente { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Observacao { get; set; }
    }
}
