using Equipment.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Equipment.Infrastructure;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var connectionString = "DataSource=equipmentdb;mode=memory;cache=shared";
        var keepAliveConnection = new SqliteConnection(connectionString);
        keepAliveConnection.Open();

        services
            .AddScoped<IEquipmentRepository, EquipmentRepository>()
            .AddScoped<IEquipmentStatusRepository, EquipmentStatusRepository>()
            .AddDbContext<EquipmentContext>(options => { options.UseSqlite(connectionString); });

        return services;
    }
}
    