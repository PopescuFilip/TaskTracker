using TaskAPI.Models;

namespace TaskAPI.Services
{
    public interface ITaskService
    {
        List<TaskModel> GetTasksByStatus(string status);
    }
}
