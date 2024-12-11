using MongoDB.Driver;
using TaskAPI.Db;
using TaskAPI.Models;

namespace TaskAPI.Services
{
    public class TaskCollectionService : EntityService<User>, ITaskService
    {
        public TaskCollectionService(TaskTrackerDbContextFactory dbContextFactory) :
            base(dbContextFactory)
        {}

        public List<TaskModel> GetTasksByStatus(string status)
        {
            using var context = _dBContextFactory.CreateDbContext();
            return context.Set<TaskModel>().Where(taskModel => taskModel.Status == status).ToList();
        }
    }
}
