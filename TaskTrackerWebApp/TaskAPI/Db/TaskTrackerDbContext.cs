using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;

namespace TaskAPI.Db
{
    public class TaskTrackerDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TaskModel>()
                .Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}
