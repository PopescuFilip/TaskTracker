using Microsoft.EntityFrameworkCore;

namespace TaskAPI.Db
{
    public class TaskTrackerDbContextFactory : IDbContextFactory<TaskTrackerDbContext>
    {
        public TaskTrackerDbContext CreateDbContext()
        {
            var dbHost = "localhost";
            var dbName = "dms_task";
            var dbPass = "m153cur3p@55";
            var connString = $"Data Source={dbHost};Initial Catalog={dbName};User=sa;Password={dbPass};TrustServerCertificate=True;";

            var options = new DbContextOptionsBuilder<TaskTrackerDbContext>()
                .UseSqlServer(connString)
                .Options;

            return new TaskTrackerDbContext(options);
        }
    }
}
