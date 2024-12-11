using TaskAPI.Db;
using TaskAPI.Models;

namespace TaskAPI.Services
{
    public abstract class UserService : EntityService<User>
    {
        protected UserService(TaskTrackerDbContextFactory dBContextFactory) : base(dBContextFactory)
        {}

        public abstract string Check(string username, string password, HttpContext context);
        public abstract bool Check(string id);
    }
}
