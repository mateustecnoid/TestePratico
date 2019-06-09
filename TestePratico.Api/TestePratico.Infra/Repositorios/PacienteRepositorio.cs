using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Dominio.Entidades;
using TestePratico.Dominio.Repositorios;
using TestePratico.Infra.Util;
using Dapper;
using System.Linq;

namespace TestePratico.Infra.Repositorios
{
    public class PacienteRepositorio : RepositorioBase, IPacienteRepositorio
    {

        public PacienteRepositorio() : base()
        {
        }

        #region[Consultas]
        const string queryInsert = @"
            INSERT INTO dbo.PACIENTE
                       (NOME,
                       DATNASCIMENTO)
                 VALUES
                       (@NOME,
                       @DATNASCIMENTO)";

        const string queryUpdate = @"
            UPDATE dbo.PACIENTE 
               SET NOME  = @NOME,
                   DATNASCIMENTO  = @DATNASCIMENTO
             WHERE CODPACIENTE  = @CODPACIENTE";

        const string queryDelete = @"
            DELETE FROM  dbo.PACIENTE 
             WHERE CODPACIENTE = @CODPACIENTE";

        const string querySelect = @"
            SELECT CODPACIENTE AS CODIGO,
	               NOME AS NOME,
	               DATNASCIMENTO AS DATANASCIMENTO 
              FROM dbo.PACIENTE
             WHERE 0 = 0";
        #endregion

        public void Atualizar(Paciente paciente)
        {
            var parametros = new DynamicParameters();
            parametros.Add("NOME", paciente.Nome);
            parametros.Add("DATNASCIMENTO", paciente.DataNascimento);
            parametros.Add("CODPACIENTE", paciente.Codigo);

            connection.Execute(queryUpdate, parametros);
        }

        public void Excluir(Paciente paciente)
        {
            connection.Execute(queryDelete, new { CODPACIENTE = paciente.Codigo });
        }

        public void Inserir(Paciente paciente)
        {
            var parametros = new DynamicParameters();
            parametros.Add("NOME", paciente.Nome);
            parametros.Add("DATNASCIMENTO", paciente.DataNascimento);

            connection.Execute(queryInsert, parametros);
        }

        public Paciente Recuperar(int codigo)
        {
            return connection.Query<Paciente>(querySelect + " AND CODPACIENTE = @CODPACIENTE", new { CODPACIENTE = codigo }).SingleOrDefault();
        }

        public IEnumerable<Paciente> Recuperar(int? codigoPaciente, string nome, DateTime? dataNascimento)
        {
            var query = new StringBuilder(querySelect);
            var parametros = new DynamicParameters();
            query.AppendLine();

            #region[Filtros]

            if (codigoPaciente != null)
            {
                query.AppendLine("AND CODPACIENTE = @CODPACIENTE");
                parametros.Add("CODPACIENTE", codigoPaciente);
            }

            if (!string.IsNullOrEmpty(nome))
            {
                query.AppendLine("AND UPPER(NOME) LIKE @NOME");
                parametros.Add("NOME", string.Format("%{0}%", nome));
            }

            if(dataNascimento != null && dataNascimento != new DateTime())
            {
                var data = dataNascimento.Value.ToUniversalTime();
                query.AppendLine("AND DATNASCIMENTO =  convert(datetime, @DATANASCIMENTO, 101)");
                parametros.Add("DATANASCIMENTO", data.ToShortDateString());
            }

            #endregion

            return connection.Query<Paciente>(query.ToString(), parametros).ToList();
        }
    }
}
