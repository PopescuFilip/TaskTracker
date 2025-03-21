using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using UserAPI.Models;

namespace UserAPI.Db
{
    public class UserTrakerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserTrakerDbContext(DbContextOptions options) : base(options)
        {
            var dbCreator = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator) ?? throw new NullReferenceException("No RelationalDatabaseCreator provided");

            if (!dbCreator.CanConnect())
                dbCreator.Create();
            if (!dbCreator.HasTables())
                dbCreator.CreateTables();
        }
    }
}
