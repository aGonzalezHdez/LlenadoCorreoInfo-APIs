using AutoMapper;
using CRUDAPIs.Application.DTOs;
using CRUDAPIs.Domain.Domain.DataBase;

namespace CRUDAPIs.Application.Mapper;

public class ConsultasMappingProfile : Profile
{
    public ConsultasMappingProfile()
    {
        CreateMap<Consultas, ConsultasDTO>().ReverseMap();
        
    }
}