using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TestePratico.Aplicacao.Servicos.Interfaces;
using TestePratico.DataTransfer.Request;
using TestePratico.DataTransfer.Response;
using TestePratico.Dominio.Entidades;
using TestePratico.Dominio.Repositorios;

namespace TestePratico.Aplicacao.Servicos
{
    public class AgendamentoAppServico : IAgendamentoAppServico
    {
        private readonly IAgendamentoRepositorio agendamentoRepositorio;
        private readonly IPacienteRepositorio pacienteRepositorio;
        private readonly IMapper mapper;

        public AgendamentoAppServico(IAgendamentoRepositorio agendamentoRepositorio, IPacienteRepositorio pacienteRepositorio, IMapper mapper)
        {
            this.agendamentoRepositorio = agendamentoRepositorio;
            this.pacienteRepositorio = pacienteRepositorio;
            this.mapper = mapper;
        }

        public void Atualizar(AgendamentoRequest request)
        {
            var agendamento = agendamentoRepositorio.Recuperar(request.Codigo);

            if (agendamento == null)
            {
                throw new Exception("Agendamento não foi encontrado");
            }

            if (agendamentoRepositorio.VerificarDisponibilidade(request.DataInicial, request.DataFinal))
            {
                throw new Exception("Horario não disponivel para agendamento");
            }

            var paciente = pacienteRepositorio.Recuperar(request.CodigoPaciente);

            if(paciente == null)
            {
                throw new Exception("Paciente não foi encontrado");
            }

            agendamento.SetPaciente(paciente);
            agendamento.SetDataConsulta(request.DataInicial, request.DataFinal);
            agendamento.SetObservacao(request.Observacao);

            agendamentoRepositorio.Atualizar(agendamento);

        }

        public void Excluir(int codigo)
        {
            var agendamento = agendamentoRepositorio.Recuperar(codigo);

            if(agendamento == null)
            {
                throw new Exception("Agendamento não foi encontrado");
            }

            agendamentoRepositorio.Excluir(agendamento);
        }

        public void Inserir(AgendamentoRequest request)
        {
            if(request == null)
            {
                throw new Exception("Request não pode ser nulo");
            }

            var paciente = pacienteRepositorio.Recuperar(request.CodigoPaciente);

            if(paciente == null)
            {
                throw new Exception("Paciente não foi encontrado");
            }

            if(agendamentoRepositorio.VerificarDisponibilidade(request.DataInicial, request.DataFinal))
            {
                throw new Exception("Horario não disponivel para agendamento");
            }

            var agendamento = new Agendamento(paciente, request.DataInicial, request.DataFinal, request.Observacao);

            agendamentoRepositorio.Inserir(agendamento);
        }

        public AgendamentoResponse Recuperar(int codigo)
        {
            return mapper.Map<Agendamento, AgendamentoResponse>(agendamentoRepositorio.Recuperar(codigo));
        }

        public IEnumerable<AgendamentoResponse> Recuperar(FiltroAgendamentoRequest request)
        {
            request = request ?? new FiltroAgendamentoRequest();

            var resultado = agendamentoRepositorio.Recuperar(request.Codigo, request.CodigoPaciente, request.DataFinal, request.DataFinal, request.Observacao);

            return mapper.Map<IEnumerable<Agendamento>, IEnumerable<AgendamentoResponse>>(resultado);
        }
    }
}
