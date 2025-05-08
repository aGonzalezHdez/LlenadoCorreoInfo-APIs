using CRUDAPIs.Application.Interfaces;
using CRUDAPIs.Application.Mapper;
using CRUDAPIs.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDAPIs.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ConsultasMappingProfile)); // 📌 Registra AutoMapper
        
        //Registro de Servicios
        services.AddScoped<IConsultasService, ConsultasesService>(); 
        return services;
    }

}