using TaskTrackerWebApp.Models;

namespace TaskTrackerWebApp.BusinessLogic
{
    public interface IUserService : IAPIService<User>
    {
        Task<string> Check(string username, string password);
    }
}
