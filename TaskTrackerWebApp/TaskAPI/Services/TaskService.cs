using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using TaskAPI.Db;
using TaskAPI.Models;

namespace TaskAPI.Services
{
    public class TaskService(IDbContextFactory<TaskTrackerDbContext> dbContextFactory) : EntityService<TaskModel>(dbContextFactory), ITaskService
    {
        public List<TaskModel> GetTasksByStatus(string status)
        {
            using var context = _dBContextFactory.CreateDbContext();
            return context.Set<TaskModel>().Where(taskModel => taskModel.Status == status).ToList();
        }
    }
}
