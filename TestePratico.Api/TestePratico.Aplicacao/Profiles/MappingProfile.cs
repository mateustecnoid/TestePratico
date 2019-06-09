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
            CreateMap<Agendamento, AgendamentoResponse>()
                .ForMember(x=> x.DataFinal, y => y.MapFrom( z => z.DataFinal.ToLocalTime()))
                .ForMember(x => x.DataInicial, y => y.MapFrom(z => z.DataInicial.ToLocalTime()));
        }
    }
}
