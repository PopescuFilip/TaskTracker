using TaskAPI.Models;

namespace TaskAPI.Services
{
    public interface IUserCollectionService : ICollectionService<User>
    {
        Task<string> Check(string username, string password, HttpContext context);
        Task<bool> Check(string id);
    }
}
