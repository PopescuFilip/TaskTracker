using TaskAPI.Db;
using TaskAPI.Models;

namespace TaskAPI.Services
{
    public interface ITaskService : ICollectionService<TaskModel>
    {
        List<TaskModel> GetTasksByStatus(string status);
    }
}
