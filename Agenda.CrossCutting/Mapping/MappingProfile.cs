using Agenda.Dominio.Dtos;
using Agenda.Dominio.Entidades;
using AutoMapper;

namespace Agenda.CrossCutting
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Agendum, AgendaDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

        }
    }
}
