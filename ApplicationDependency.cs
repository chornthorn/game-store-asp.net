using GameStore.Api.Core.database;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.DI;

public static class ApplicationDependency
{
    // database connection
    public static IServiceCollection ApplyDbConnection(this IServiceCollection services)
    {
        var dbConnection = services.BuildServiceProvider().GetService<IConfiguration>()?.GetConnectionString("DefaultConnection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 2));
        services.AddDbContext<GameStoreContext>(options => options.UseMySql(dbConnection, serverVersion: serverVersion));
        return services;
    }

    // Initialize database
    public static void InitializeDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<GameStoreContext>();
        context.Database.Migrate();
    }

    public static IServiceCollection ManualDependency(this IServiceCollection services)
    {
        // Apply database connection
        services.ApplyDbConnection();

        // Add injectables here:

        return services;
    }
}
