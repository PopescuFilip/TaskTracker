using Microsoft.EntityFrameworkCore;
using UserAPI.Db;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserService(IDbContextFactory<UserDbContext> dbContextFactory) : EntityService<User>(dbContextFactory), IUserService
    {
        public override bool Create(User model)
        {
            using var context = _dBContextFactory.CreateDbContext();
            if (context.Set<User>().Where(u => u.Name == model.Name).Any())
                return false;

            return base.Create(model);
        }

        public string Check(string username, string password)
        {
            using var dbContext = _dBContextFactory.CreateDbContext();
            var user = dbContext.Set<User>().FirstOrDefault(u => u.Name == username && u.Password == password);

            if (user != null)
                return user.Id.ToString();

            return string.Empty;
        }

        public bool Check(string id)
        {
            if (!Guid.TryParse(id, out Guid userGuid))
                return false;

            using var context = _dBContextFactory.CreateDbContext();
            return Get(userGuid) != null;
        }
    }
}
