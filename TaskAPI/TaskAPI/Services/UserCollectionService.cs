using MongoDB.Driver;
using TaskAPI.Db;
using TaskAPI.Models;

namespace TaskAPI.Services
{
    public class UserCollectionService : UserService
    {
        public UserCollectionService(TaskTrackerDbContextFactory dbContextFactory) :
            base(dbContextFactory)
        {}

        public override string Check(string username, string password, HttpContext context)
        {
            using var dbContext = _dBContextFactory.CreateDbContext();
            var user = dbContext.Set<User>().FirstOrDefault(u => u.Name == username && u.Password == password);

            if (user != null)
            {
                context.Session.SetString("id", user.Id.ToString());
                return user.Id.ToString();
            }
            return string.Empty;
        }

        public override bool Check(string id)
        {
            if (!Guid.TryParse(id, out Guid userGuid))
                return false;

            using var context = _dBContextFactory.CreateDbContext();
            return Get(userGuid) != null;
        }
    }
}
