using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Dominio.Entidades;

namespace TestePratico.Dominio.Repositorios
{
    public interface IAgendamentoRepositorio
    {
        void Inserir(Agendamento agendamento);
        void Atualizar(Agendamento agendamento);
        void Excluir(Agendamento agendamento);
        Agendamento Recuperar(int codigo);
        IEnumerable<Agendamento> Recuperar(int? codigoAgendamento, int? codigoPaciente, DateTime? dataInicio, DateTime? dataFim, string observacao);
    }
}
