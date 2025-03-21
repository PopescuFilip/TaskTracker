using Microsoft.EntityFrameworkCore;

namespace UserAPI.Db
{
    public class UserTrakerDbContextFactory: IDbContextFactory<UserTrakerDbContext>
    {
        private readonly string _connectionString;

        public UserTrakerDbContextFactory()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "dms_user";
            var dbPass = Environment.GetEnvironmentVariable("DB_SA_PASSWORD") ?? "m153cur3p@55";
            _connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User=sa;Password={dbPass};TrustServerCertificate=True;";
        }

        public UserTrakerDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<UserTrakerDbContext>()
                .UseSqlServer(_connectionString)
                .Options;

            return new UserTrakerDbContext(options);
        }
    }
}
