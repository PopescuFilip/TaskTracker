using System.Text;
using System.Text.Json;
using TaskTrackerWebApp.Models;

namespace TaskTrackerWebApp.BusinessLogic
{
    public class UserService : IUserService
    {
        private const string BaseUrl = "http://localhost:5126/User";
        private readonly JsonSerializerOptions _serializerOptions;

        public UserService()
        {
            _serializerOptions = new()
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<User>> GetAll()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(BaseUrl);
            var responseString = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(responseString, _serializerOptions);
            return users ?? [];
        }

        public async Task<User> Get(Guid id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{BaseUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(responseString, _serializerOptions);
                return user;
            }
            return null;
        }

        public async Task<bool> Post(User model)
        {
            using var client = new HttpClient();
            var userJson = JsonSerializer.Serialize(model, _serializerOptions);
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(BaseUrl, content);

            return response.IsSuccessStatusCode;
        }

        public async Task Update(Guid id, User model)
        {
            using var client = new HttpClient();
            var userJson = JsonSerializer.Serialize(model, _serializerOptions);
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{BaseUrl}/{id}", content);
        }

        public async Task Delete(Guid id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{BaseUrl}/{id}");
        }

        public async Task<string> Check(string username, string password)
        {
            using var client = new HttpClient();

            var loginData = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            var content = new StringContent(
                JsonSerializer.Serialize(loginData, _serializerOptions),
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync($"{BaseUrl}/login", content);

            return await response.Content.ReadAsStringAsync();
        }

    }
}
