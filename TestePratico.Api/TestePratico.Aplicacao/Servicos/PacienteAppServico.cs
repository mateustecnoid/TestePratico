using AutoMapper;
using System;
using System.Collections.Generic;
using TestePratico.Aplicacao.Servicos.Interfaces;
using TestePratico.DataTransfer.Request;
using TestePratico.DataTransfer.Response;
using TestePratico.Dominio.Entidades;
using TestePratico.Dominio.Repositorios;

namespace TestePratico.Aplicacao.Servicos
{
    public class PacienteAppServico : IPacienteAppServico
    {
        private readonly IPacienteRepositorio pacienteRepositorio;
        private readonly IMapper mapper;

        public PacienteAppServico(IPacienteRepositorio pacienteRepositorio, IMapper mapper)
        {
            this.pacienteRepositorio = pacienteRepositorio;
            this.mapper = mapper;
        }

        public void Atualizar(PacienteRequest request)
        {
            var paciente = pacienteRepositorio.Recuperar(request.Codigo);

            if (paciente == null)
            {
                throw new Exception("Paciente não foi encontrado");
            }

            paciente.SetNome(request.Nome);
            paciente.SetDataNascimento(request.DataNascimento);

            pacienteRepositorio.Atualizar(paciente);
        }

        public void Excluir(int codigo)
        {
            var paciente = pacienteRepositorio.Recuperar(codigo);

            if (paciente == null)
            {
                throw new Exception("Paciente não foi encontrado");
            }

            pacienteRepositorio.Excluir(paciente);
        }

        public void Inserir(PacienteRequest request)
        {
            if (request == null)
            {
                throw new Exception("Request não pode ser invalido");
            }

            var paciente = new Paciente(request.Nome, request.DataNascimento);

            pacienteRepositorio.Inserir(paciente);
        }

        public PacienteResponse Recuperar(int codigo)
        {
            return mapper.Map<Paciente, PacienteResponse>(pacienteRepositorio.Recuperar(codigo));
        }

        public IEnumerable<PacienteResponse> Recuperar(FiltroPacienteRequest request)
        {
            request = request ?? new FiltroPacienteRequest();

            var reponse = pacienteRepositorio.Recuperar(request.Codigo, request.Nome, request.DataNascimento);

            return mapper.Map<IEnumerable<Paciente>, IEnumerable<PacienteResponse>>(reponse);
        }
    }
}
