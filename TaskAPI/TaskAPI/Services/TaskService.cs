using MongoDB.Driver;
using TaskAPI.Db;
using TaskAPI.Models;

namespace TaskAPI.Services
{
    public class TaskService : BaseTaskService
    {
        public TaskService(TaskTrackerDbContextFactory dbContextFactory) :
            base(dbContextFactory)
        {}

        public override List<TaskModel> GetTasksByStatus(string status)
        {
            using var context = _dBContextFactory.CreateDbContext();
            return context.Set<TaskModel>().Where(taskModel => taskModel.Status == status).ToList();
        }
    }
}
