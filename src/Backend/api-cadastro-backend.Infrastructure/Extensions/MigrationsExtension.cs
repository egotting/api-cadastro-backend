using api_cadastro_backend.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace api_cadastro_backend.Infrastructure.Extensions;

public static class MigrationsExtension
{
    public async static Task RunMigrations(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var service = scope.ServiceProvider;
            int maxRetryAttempts = 2;
            int delayBetweenRetries = 2000;

            for (int attempt = 0; attempt < maxRetryAttempts; attempt++)
            {
                try
                {
                    var dbContext = service.GetRequiredService<DataContext>();
                    var pendingMigrations = dbContext.Database.GetPendingMigrations();
                    if (pendingMigrations.Any())
                    {
                        Console.WriteLine($"Há migrações pendentes: {pendingMigrations.Count()}");
                        dbContext.Database.Migrate();
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma migração pendente foi encontrada");
                    }

                    break;
                }
                catch (PostgresException ex)
                {
                    if (ex.SqlState == "42P07")
                    {
                        Console.WriteLine("Erro: uma tabela ja existe");
                        break;
                    }

                    Console.WriteLine($"Erro ao verificar/aplicar migrações (tentativa {attempt + 1}): {ex.Message}))");

                    if (attempt < maxRetryAttempts - 1)
                    {
                        Console.WriteLine($"aguarde {delayBetweenRetries / 1000} segundos antes de tentar novamente...");
                        await Task.Delay(delayBetweenRetries);
                    }
                    else
                    {
                        throw;
                    }
                }
            }

        }
    }
}