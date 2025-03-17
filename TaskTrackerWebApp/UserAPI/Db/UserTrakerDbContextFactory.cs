using Microsoft.EntityFrameworkCore;

namespace UserAPI.Db
{
    public class UserTrakerDbContextFactory: IDbContextFactory<UserTrakerDbContext>
    {
        public UserTrakerDbContext CreateDbContext()
        {
            var dbHost = "localhost";
            var dbName = "dms_user";
            var dbPass = "m153cur3p@55";
            var connString = $"Data Source={dbHost};Initial Catalog={dbName};User=sa;Password={dbPass};TrustServerCertificate=True;";

            var options = new DbContextOptionsBuilder<UserTrakerDbContext>()
                .UseSqlServer(connString)
                .Options;

            return new UserTrakerDbContext(options);
        }
    }
}
