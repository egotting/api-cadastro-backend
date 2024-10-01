using api_cadastro_backend.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace api_cadastro_backend.Infrastructure.Data.Configuration;

public static class DBConfigurationConnection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddDbContext(services);
    }

    private static void AddDbContext(IServiceCollection services)
    {
        var connectionString =
            "User ID=postgres;Password=2342;Host=localhost;Port=5432;Database=UserDataRegister;Pooling=true;Connection Lifetime=0;";
        services.AddDbContext<DataContext>(options => 
            options.UseNpgsql(connectionString));
    }
}