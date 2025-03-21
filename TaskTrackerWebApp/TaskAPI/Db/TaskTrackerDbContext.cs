using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using TaskAPI.Models;

namespace TaskAPI.Db
{
    public class TaskTrackerDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }

        public TaskTrackerDbContext(DbContextOptions options) : base(options)
        {
            var dbCreator = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator) ?? throw new NullReferenceException("No RelationalDatabaseCreator provided");

            if (!dbCreator.CanConnect())
                dbCreator.Create();
            if (!dbCreator.HasTables())
                dbCreator.CreateTables();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TaskModel>()
                .Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}
