using TaskTrackerWebApp.Models;

namespace TaskTrackerWebApp.BusinessLogic
{
    public interface ITaskService : IAPIService<TaskModel>
    {
        Task<List<TaskModel>> GetTasksByStatus(string status);
    }
}
