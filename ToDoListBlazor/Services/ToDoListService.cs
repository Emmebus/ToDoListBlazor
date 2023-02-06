using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using ToDoListBlazor.Models;

namespace ToDoListBlazor.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly HttpClient _client;
        public ToDoListService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient();
        }

        public async Task<ServiceResponse<ToDoList>> AddToDoList(string title)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7077/AddToDoList/{title}");
            HttpResponseMessage response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ServiceResponse<ToDoList>>();
        }

        public async Task<ServiceResponse<Models.Task>> AddTask(string description, int toDoListId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7077/AddTask/{description}/{toDoListId}");
            HttpResponseMessage response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ServiceResponse<Models.Task>>();
        }

        public async Task<ServiceResponse<List<ToDoList>>> GetAllToDoLists()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7077/GetAllToDoLists");
            HttpResponseMessage response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ServiceResponse<List<ToDoList>>>();
        }

        public async Task<ServiceResponse<ToDoList>> GetToDoListById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7077/Gettodolists/{id}");
            HttpResponseMessage response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ServiceResponse<ToDoList>>();
        }

        public async Task<ServiceResponse<Models.Task>> UpdateTask(int id, string? description, bool? completed, int? toDoListId)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7077/UpdateTask/{id}?newDescription={description}&completed={completed}&toDoListId={toDoListId}");
            HttpResponseMessage response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            try
            {
                return await response.Content.ReadFromJsonAsync<ServiceResponse<Models.Task>>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ServiceResponse<ToDoList>> UpdateToDoList(int id, string newTitle)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7077/UpdateToDoLists/{id}/{newTitle}");
            HttpResponseMessage response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ServiceResponse<ToDoList>>();
        }
        
        public async Task<ServiceResponse<Models.Task>> DeleteTask(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7077/DeleteTask/{id}");
            HttpResponseMessage response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ServiceResponse<Models.Task>>();
        }

        public async Task<ServiceResponse<ToDoList>> DeleteToDoList(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7077/DeleteToDoLists/{id}");
            HttpResponseMessage response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ServiceResponse<ToDoList>>();
        }

    }
}
