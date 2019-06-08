using System;
using System.Collections.Generic;
using System.Text;

namespace TestePratico.DataTransfer.Request
{
    public class FiltroAgendamentoRequest
    {
        public int? Codigo { get; set; }
        public int? CodigoPaciente { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string Observacao { get; protected set; }
    }
}
