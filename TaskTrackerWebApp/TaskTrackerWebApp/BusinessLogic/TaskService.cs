﻿using System.Net;
using System.Text;
using System.Text.Json;
using TaskTrackerWebApp.Models;

namespace TaskTrackerWebApp.BusinessLogic
{
    public class TaskService : ITaskService
    {
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _serializerOptions;

        public TaskService()
        {
            var taskApiHost = Environment.GetEnvironmentVariable("TASK_API_HOST") ?? "localhost:5126";
            _baseUrl = $"http://{taskApiHost}/Task";
            _serializerOptions = new()
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<TaskModel>> GetAll()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(_baseUrl);
            var responseString = await response.Content.ReadAsStringAsync();
            var tasks = JsonSerializer.Deserialize<List<TaskModel>>(responseString, _serializerOptions);
            return tasks ?? [];
        }

        public async Task<TaskModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(TaskModel model)
        {
            using var client = new HttpClient();
            var taskJson = JsonSerializer.Serialize(model, _serializerOptions);
            var content = new StringContent(taskJson, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(_baseUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task Update(Guid id, TaskModel model)
        {
            using var client = new HttpClient();
            var taskJson = JsonSerializer.Serialize(model, _serializerOptions);
            var content = new StringContent(taskJson, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(_baseUrl, content);
        }

        public async Task Delete(Guid id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{_baseUrl}/{id}");
        }

        public Task<List<TaskModel>> GetTasksByStatus(string status)
        {
            throw new NotImplementedException();
        }
    }

}
