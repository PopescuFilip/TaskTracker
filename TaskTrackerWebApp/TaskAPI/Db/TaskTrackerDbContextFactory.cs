using Microsoft.EntityFrameworkCore;

namespace TaskAPI.Db;

public class TaskTrackerDbContextFactory : IDbContextFactory<TaskTrackerDbContext>
{
    private readonly string _connectionString;

    public TaskTrackerDbContextFactory()
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
        var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "dms_task";
        var dbPass = Environment.GetEnvironmentVariable("DB_SA_PASSWORD") ?? "m153cur3p@55";
        _connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User=sa;Password={dbPass};TrustServerCertificate=True;";
    }

    public TaskTrackerDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<TaskTrackerDbContext>()
            .UseSqlServer(_connectionString)
            .Options;

        return new TaskTrackerDbContext(options);
    }
}