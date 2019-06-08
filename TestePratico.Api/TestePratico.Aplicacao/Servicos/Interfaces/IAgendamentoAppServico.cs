using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.DataTransfer.Request;
using TestePratico.DataTransfer.Response;

namespace TestePratico.Aplicacao.Servicos.Interfaces
{
    public interface IAgendamentoAppServico
    {
        void Inserir(AgendamentoRequest request);
        void Atualizar(AgendamentoRequest request);
        void Excluir(int codigo);
        AgendamentoResponse Recuperar(int codigo);
        IEnumerable<AgendamentoResponse> Recuperar(FiltroAgendamentoRequest request);
    }
}
