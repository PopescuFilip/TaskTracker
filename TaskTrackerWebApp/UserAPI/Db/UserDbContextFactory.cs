using Microsoft.EntityFrameworkCore;

namespace UserAPI.Db;

public class UserDbContextFactory: IDbContextFactory<UserDbContext>
{
    private readonly string _connectionString;

    public UserDbContextFactory()
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
        var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "dms_user";
        var dbPass = Environment.GetEnvironmentVariable("DB_SA_PASSWORD") ?? "m153cur3p@55";
        _connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User=sa;Password={dbPass};TrustServerCertificate=True;";
    }

    public UserDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<UserDbContext>()
            .UseSqlServer(_connectionString)
            .Options;

        return new UserDbContext(options);
    }
}