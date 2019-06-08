using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.DataTransfer.Request;
using TestePratico.DataTransfer.Response;

namespace TestePratico.Aplicacao.Servicos.Interfaces
{
    public interface IPacienteAppServico
    {
        void Inserir(PacienteRequest request);
        void Atualizar(PacienteRequest request);
        void Excluir(int codigo);
        PacienteResponse Recuperar(int codigo);
        IEnumerable<PacienteResponse> Recuperar(FiltroPacienteRequest request);
    }
}
