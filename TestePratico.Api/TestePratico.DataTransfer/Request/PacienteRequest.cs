using System;

namespace TestePratico.DataTransfer.Request
{
    public class PacienteRequest
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
