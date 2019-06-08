using System;
using System.Collections.Generic;
using System.Text;

namespace TestePratico.DataTransfer.Request
{
    public class FiltroPacienteRequest
    {
        public int? Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
