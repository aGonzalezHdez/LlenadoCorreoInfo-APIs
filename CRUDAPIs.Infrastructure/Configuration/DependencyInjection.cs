using CRUDAPIs.Application.Interfaces;
using CRUDAPIs.Infrastructure.DataBase;
using CRUDAPIs.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDAPIs.Infrastructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContextFactory<MySQLDBContext>();
        services.AddScoped(typeof(IDBServices<>), typeof(DBServices<>));
        return services;
    }
}
