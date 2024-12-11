using MongoDB.Driver;
using TaskAPI.Models;
using TaskAPI.Settings;

namespace TaskAPI.Services
{
    public class UserCollectionService : IUserCollectionService
    {
        private readonly IMongoCollection<User> _users;

        public UserCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public async Task<string> Check(string username, string password, HttpContext context)
        {
            var user = (await _users.FindAsync(u => u.Name == username && u.Password == password)).FirstOrDefault();
            if (user != null)
            {
                context.Session.SetString("id", user.Id.ToString());
                return user.Id.ToString();
            }

            return string.Empty;
        }

        public async Task<bool> Check(string id)
        {
            if (!Guid.TryParse(id, out Guid userGuid))
            {
                return false;
            }
            var user = (await _users.FindAsync(u => u.Id == userGuid)).FirstOrDefault();
            if (user != null)
            {                
                return true;
            }
            return false;
        }

        public async Task<bool> Create(User model)
        {
            if (model.Id == Guid.Empty)
            {
                model.Id = Guid.NewGuid();
            }

            await _users.InsertOneAsync(model);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _users.DeleteOneAsync(user => user.Id == id);
            if (!result.IsAcknowledged || result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<User> Get(Guid id)
        {
            return (await _users.FindAsync(user => user.Id == id)).FirstOrDefault();
        }

        public async Task<List<User>> GetAll()
        {
            var result = await _users.FindAsync(user => true);
            return result.ToList();
        }

        public async Task<bool> Update(Guid id, User model)
        {
            model.Id = id;
            var result = await _users.ReplaceOneAsync(user => user.Id == id, model);
            if (!result.IsAcknowledged || result.ModifiedCount == 0)
            {
                return false;
            }
            return true;
        }
    }
}
