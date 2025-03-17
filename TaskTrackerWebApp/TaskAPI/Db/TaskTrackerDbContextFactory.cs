using Microsoft.EntityFrameworkCore;

namespace TaskAPI.Db
{
    public class TaskTrackerDbContextFactory : IDbContextFactory<TaskTrackerDbContext>
    {
        private const string CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb;Database=TaskTrackerDb;Trusted_Connection=True;";

        public TaskTrackerDbContext CreateDbContext()
        {
            //var dbHost = "localhost";
            //var dbName = "dms_user";
            //var dbPass = "m153cur3p@55";
            //var connString = $"Data Source={dbHost};Initial Catalog={dbName};User=sa;Password={dbPass}";

            var options = new DbContextOptionsBuilder<TaskTrackerDbContext>();
            options.UseSqlServer(CONNECTION_STRING);

            return new TaskTrackerDbContext(options.Options);
        }
    }
}
