using AutoMapper;
using TestePratico.DataTransfer.Response;
using TestePratico.Dominio.Entidades;

namespace TestePratico.Aplicacao.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Paciente, PacienteResponse>();
            CreateMap<Agendamento, AgendamentoResponse>();
        }
    }
}
