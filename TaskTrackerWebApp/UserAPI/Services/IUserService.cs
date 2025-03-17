using UserAPI.Models;

namespace UserAPI.Services
{
    public interface IUserService : ICollectionService<User>
    {
        string Check(string username, string password);
        bool Check(string id);
    }
}
