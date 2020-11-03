using Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SiteProjeto.Models.Services
{
    public class ProjectService
    {
        private readonly RestClient client;

        private const string BASE_REQUEST = "projects";

        public ProjectService(IConfiguration configuration)
        {
            client = new RestClient(configuration.GetSection("urlAPI").Value);
        }

        public async Task<ResponseAPI<List<Project>>> GetAll()
        {
            ResponseAPI<List<Project>> responseAPI = new ResponseAPI<List<Project>>();

            var request = new RestRequest(BASE_REQUEST);

            var response = await client.ExecuteAsync<List<Project>>(request, Method.GET);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode == HttpStatusCode.BadRequest)
                ? null
                : JsonConvert.DeserializeObject<List<Project>>(response.Content);

            return responseAPI;
        }

        public async Task<ResponseAPI<Project>> Get(int id)
        {
            ResponseAPI<Project> responseAPI = new ResponseAPI<Project>();

            var request = new RestRequest(BASE_REQUEST + "/{id}")
                .AddUrlSegment("id", id);

            var response = await client.ExecuteAsync<Project>(request, Method.GET);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode != HttpStatusCode.OK)
                ? null
                : JsonConvert.DeserializeObject<Project>(response.Content);

            return responseAPI;
        }

        public async Task<ResponseAPI<int>> Post(Project project)
        {
            ResponseAPI<int> responseAPI = new ResponseAPI<int>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(project);

            var response = await client.ExecuteAsync<dynamic>(request, Method.POST);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode == HttpStatusCode.BadRequest)
                ? 0
                : JsonConvert.DeserializeObject<dynamic>(response.Content).id;

            return responseAPI;
        }

        public async Task<ResponseAPI<object>> Put(Project project)
        {
            ResponseAPI<object> responseAPI = new ResponseAPI<object>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(project);

            var response = await client.ExecuteAsync(request, Method.PUT);

            responseAPI.StatusCode = (int)response.StatusCode;

            return responseAPI;
        }

        public async Task<ResponseAPI<object>> Delete(int id)
        {
            ResponseAPI<object> responseAPI = new ResponseAPI<object>();

            var request = new RestRequest(BASE_REQUEST + "/{id}")
                .AddUrlSegment("id", id);

            var response = await client.ExecuteAsync(request, Method.DELETE);

            responseAPI.StatusCode = (int)response.StatusCode;

            return responseAPI;
        }
    }
}
