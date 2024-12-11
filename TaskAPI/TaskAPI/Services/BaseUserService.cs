using TaskAPI.Db;
using TaskAPI.Models;

namespace TaskAPI.Services
{
    public abstract class BaseUserService : EntityService<User>
    {
        protected BaseUserService(TaskTrackerDbContextFactory dbContextFactory) : base(dbContextFactory)
        {}

        public abstract string Check(string username, string password, HttpContext context);
        public abstract bool Check(string id);
    }
}
