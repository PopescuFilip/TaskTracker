using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;

namespace TaskAPI.Db
{
    public class TaskTrackerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        public TaskTrackerDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TaskModel>()
                .Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}
