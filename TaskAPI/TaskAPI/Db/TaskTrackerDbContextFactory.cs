using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace TaskAPI.Db
{
    public class TaskTrackerDbContextFactory : IDesignTimeDbContextFactory<TaskTrackerDbContext>
    {
        private const string CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb;Database=TaskTrackerDb;Trusted_Connection=True;";
        public TaskTrackerDbContext CreateDbContext(string[]? args = null)
        {
            var options = new DbContextOptionsBuilder<TaskTrackerDbContext>();
            options.UseSqlServer(CONNECTION_STRING);

            return new TaskTrackerDbContext(options.Options);
        }
    }
}
