using TaskAPI.Db;
using TaskAPI.Models;

namespace TaskAPI.Services
{
    public abstract class BaseTaskService : EntityService<TaskModel>
    {
        protected BaseTaskService(TaskTrackerDbContextFactory dbContextFactory) : base(dbContextFactory)
        {}

        public abstract List<TaskModel> GetTasksByStatus(string status);
    }
}
