using Microsoft.EntityFrameworkCore;
using UserAPI.Db;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class EntityService<T>(IDbContextFactory<UserDbContext> dBContextFactory) : ICollectionService<T> where T : Entity
    {
        protected readonly IDbContextFactory<UserDbContext> _dBContextFactory = dBContextFactory;

        public virtual List<T> GetAll()
        {
            using var context = _dBContextFactory.CreateDbContext();
            return context.Set<T>().ToList();
        }

        public virtual T Get(Guid id)
        {
            using var context = _dBContextFactory.CreateDbContext();
            return context.Set<T>().Single(e => e.Id == id);
        }

        public virtual bool Create(T model)
        {
            using var context = _dBContextFactory.CreateDbContext();
            context.Set<T>().Add(model);
            context.SaveChanges();
            return true;
        }

        public virtual bool Update(Guid id, T model)
        {
            using var context = _dBContextFactory.CreateDbContext();
            context.Set<T>().Update(model);
            context.SaveChanges();
            return true;
        }

        public virtual bool Delete(Guid id)
        {
            using var context = _dBContextFactory.CreateDbContext();
            var entityToDelete = Get(id);
            context.Set<T>().Remove(entityToDelete);
            context.SaveChanges();
            return true;
        }
    }
}
