using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestePratico.Dominio.Entidades;
using TestePratico.Dominio.Repositorios;
using TestePratico.Infra.Util;

namespace TestePratico.Infra.Repositorios
{
    public class AgendamentoRepositorio : RepositorioBase, IAgendamentoRepositorio
    {
        #region [Consultas]

        const string querySelect = @"
            SELECT A.CODAGENDAMENTO AS CODIGO,
                   A.DATFIMCONSULTA AS DATAFINAL,
                   A.DATINICIOCONSULTA AS DATAINICIAL,
                   A.OBSERVACAO AS OBSERVACAO,
                   P.CODPACIENTE AS CODIGO,
                   P.NOME AS NOME,
                   P.DATNASCIMENTO AS DATANASCIMENTO
	   
              FROM PACIENTE P
             INNER JOIN AGENDAMENTO A ON P.CODPACIENTE = A.CODPACIENTE";

        const string queryInsert = @"
            INSERT INTO dbo.AGENDAMENTO 
                        (CODPACIENTE, 
                        DATINICIOCONSULTA, 
                        DATFIMCONSULTA, 
                        OBSERVACAO)
                VALUES (@CODPACIENTE, 
                        @DATINICIOCONSULTA, 
                        @DATFIMCONSULTA, 
                        @OBSERVACAO);";

        const string queryUpdate = @"
            UPDATE dbo.AGENDAMENTO
               SET CODPACIENTE = @CODPACIENTE, 
                   DATINICIOCONSULTA = @DATINICIOCONSULTA, 
                   DATFIMCONSULTA = @DATFIMCONSULTA, 
                   OBSERVACAO = @OBSERVACAO
             WHERE CODAGENDAMENTO = @CODAGENDAMENTO";


        const string queryDelete = @"
            DELETE FROM dbo.AGENDAMENTO
                    WHERE CODAGENDAMENTO = @CODAGENDAMENTO";

        #endregion

        public void Atualizar(Agendamento agendamento)
        {
            var parametros = new DynamicParameters();
            parametros.Add("CODAGENDAMENTO", agendamento.Codigo);
            parametros.Add("CODPACIENTE", agendamento.Paciente.Codigo);
            parametros.Add("DATINICIOCONSULTA", agendamento.DataInicial);
            parametros.Add("DATFIMCONSULTA", agendamento.DataFinal);
            parametros.Add("OBSERVACAO", agendamento.Observacao);

            connection.Execute(queryUpdate, parametros);
        }

        public void Excluir(Agendamento agendamento)
        {
            connection.Execute(queryDelete, new { CODAGENDAMENTO = agendamento.Codigo });
        }

        public void Inserir(Agendamento agendamento)
        {
            var parametros = new DynamicParameters();
            parametros.Add("CODPACIENTE", agendamento.Paciente.Codigo);
            parametros.Add("DATINICIOCONSULTA", agendamento.DataInicial);
            parametros.Add("DATFIMCONSULTA", agendamento.DataFinal);
            parametros.Add("OBSERVACAO", agendamento.Observacao);

            connection.Execute(queryInsert, parametros);
        }

        public Agendamento Recuperar(int codigo)
        {
            return connection.Query<Agendamento, Paciente, Agendamento>(querySelect + " AND A.CODAGENDAMENTO = @CODAGENDAMENTO", (agendamento, paciente) =>
             {
                 agendamento.Paciente = paciente;
                 return agendamento;
             }, new { CODAGENDAMENTO = codigo }, splitOn: "CODIGO, CODIGO").SingleOrDefault();
        }

        public IEnumerable<Agendamento> Recuperar(int? codigoAgendamento, int? codigoPaciente, DateTime? dataInicio, DateTime? dataFim, string observacao)
        {
            var query = new StringBuilder(querySelect);
            var parametros = new DynamicParameters();

            query.AppendLine();

            #region[Filtros]

            if (codigoAgendamento != null)
            {
                query.AppendLine("AND A.CODAGENDAMENTO = @CODAGENDAMENTO");
                parametros.Add("CODAGENDAMENTO", codigoAgendamento);
            }

            if (codigoPaciente != null)
            {
                query.AppendLine("AND P.CODPACIENTE = @CODPACIENTE");
                parametros.Add("CODPACIENTE", codigoPaciente);
            }

            if (dataInicio != null && dataInicio != new DateTime())
            {
                query.AppendLine("AND A.DATINICIOCONSULTA >= @DATINICIOCONSULTA");
                parametros.Add("DATINICIOCONSULTA", dataInicio);
            }

            if (dataFim != null && dataFim != new DateTime())
            {
                query.AppendLine("AND A.DATFIMCONSULTA <= @DATFIMCONSULTA");
                parametros.Add("DATFIMCONSULTA", dataFim);
            }

            if (!string.IsNullOrEmpty(observacao))
            {
                query.AppendLine("AND UPPER(A.OBSERVACAO) LIKE UPPER(@OBSERVACAO)");
                parametros.Add("OBSERVACAO", string.Format("{0}", observacao));
            }

            #endregion

            return connection.Query<Agendamento, Paciente, Agendamento>(querySelect, (agendamento, paciente) =>
            {
                agendamento.Paciente = paciente;
                return agendamento;
            }, parametros, splitOn: "CODIGO, CODIGO").ToList();
        }
    }
}
