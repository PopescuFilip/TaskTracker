using System.Text;
using System.Text.Json;
using TaskTrackerWebApp.Models;

namespace TaskTrackerWebApp.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _serializerOptions;

        public UserService()
        {
            var userApiHost = Environment.GetEnvironmentVariable("USER_API_HOST") ?? "localhost:5063";
            _baseUrl = $"http://{userApiHost}/User";
            _serializerOptions = new()
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<User>> GetAll()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(_baseUrl);
            var responseString = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(responseString, _serializerOptions);
            return users ?? [];
        }

        public async Task<User> Get(Guid id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id}");
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

            var response = await client.PostAsync(_baseUrl, content);

            return response.IsSuccessStatusCode;
        }

        public async Task Update(Guid id, User model)
        {
            using var client = new HttpClient();
            var userJson = JsonSerializer.Serialize(model, _serializerOptions);
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{_baseUrl}/{id}", content);
        }

        public async Task Delete(Guid id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{_baseUrl}/{id}");
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

            var response = await client.PostAsync($"{_baseUrl}/login", content);

            return await response.Content.ReadAsStringAsync();
        }

    }
}
