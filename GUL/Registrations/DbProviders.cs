using GUL.Persistence.Context;
using GUL.Persistence.UnitOfWork;
using GUL.Shared.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GUL.Registrations;

public static class DbProviders
{
    public static void AddDbProvidersRegistration(this IServiceCollection services, PosConfiguration configuration)
    {
        switch (configuration.Database.DbProvider)
        {
            case DbProvider.PostgreSql:
                services.AddDbContext<IPosDbContext, PosDbContext>(o => { o.UseNpgsql(configuration.Database.BuildConnectionString() ?? string.Empty); });
                //services.AddDbContext<IUsersDbContext, UsersDbContext>(o => { o.UseNpgsql(configuration.Database.BuildConnectionString() ?? string.Empty); });
                break;
            case DbProvider.MsSql:
                services.AddDbContext<IPosDbContext, PosDbContext>(o => { o.UseSqlServer(configuration.Database.BuildConnectionString() ?? string.Empty); });
                //services.AddDbContext<IUsersDbContext, UsersDbContext>(o => { o.UseSqlServer(configuration.Database.BuildConnectionString() ?? string.Empty); });
                break;
            case DbProvider.MySql:
                var connectionString = configuration.Database.BuildConnectionString() ?? string.Empty;
                services.AddDbContext<IPosDbContext, PosDbContext>(o => { o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); });
                //services.AddDbContext<IUsersDbContext, UsersDbContext>(o => { o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); });
                break;
            case DbProvider.SqLlite:
                services.AddDbContext<IPosDbContext, PosDbContext>(o => { o.UseSqlite(configuration.Database.BuildConnectionString() ?? string.Empty); });
                //services.AddDbContext<IUsersDbContext, UsersDbContext>(o => { o.UseSqlite(configuration.Database.BuildConnectionString() ?? string.Empty); });
                break;
            default:
                services.AddDbContext<IPosDbContext, PosDbContext>(o => { o.UseInMemoryDatabase(configuration.Database.BuildConnectionString() ?? string.Empty); });
                //services.AddDbContext<IUsersDbContext, UsersDbContext>(o => { o.UseInMemoryDatabase(configuration.Database.BuildConnectionString() ?? string.Empty); });
                break;
        }

        //services.AddScoped<IPosDbContext>(c => c.GetRequiredService<PosDbContext>());
        services.AddScoped<IUnitOfWork>(c => (IUnitOfWork)c.GetRequiredService<PosDbContext>());
    }
}
