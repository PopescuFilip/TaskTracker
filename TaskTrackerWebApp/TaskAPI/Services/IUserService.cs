using TaskAPI.Db;
using TaskAPI.Models;

namespace TaskAPI.Services
{
    public interface IUserService : ICollectionService<User>
    {
        string Check(string username, string password);
        bool Check(string id);
    }
}
