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

        public ResponseAPI<List<Project>> GetAll()
        {
            ResponseAPI<List<Project>> responseAPI = new ResponseAPI<List<Project>>();

            var request = new RestRequest(BASE_REQUEST);

            var response = client.Get<List<Project>>(request);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode == HttpStatusCode.BadRequest)
                ? null
                : JsonConvert.DeserializeObject<List<Project>>(response.Content);

            return responseAPI;
        }

        public ResponseAPI<Project> Get(int id)
        {
            ResponseAPI<Project> responseAPI = new ResponseAPI<Project>();

            var request = new RestRequest(BASE_REQUEST + "/{id}")
                .AddUrlSegment("id", id);

            var response = client.Get<Project>(request);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode != HttpStatusCode.OK)
                ? null
                : JsonConvert.DeserializeObject<Project>(response.Content);

            return responseAPI;
        }

        public ResponseAPI<int> Post(Project project)
        {
            ResponseAPI<int> responseAPI = new ResponseAPI<int>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(project);

            var response = client.Post<dynamic>(request);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode == HttpStatusCode.BadRequest)
                ? 0
                : JsonConvert.DeserializeObject<dynamic>(response.Content).id;

            return responseAPI;
        }

        public ResponseAPI<object> Put(Project project)
        {
            ResponseAPI<object> responseAPI = new ResponseAPI<object>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(project);

            var response = client.Put(request);

            responseAPI.StatusCode = (int)response.StatusCode;

            return responseAPI;
        }

        public ResponseAPI<object> Delete(int id)
        {
            ResponseAPI<object> responseAPI = new ResponseAPI<object>();

            var request = new RestRequest(BASE_REQUEST + "/{id}")
                .AddUrlSegment("id", id);

            var response = client.Delete(request);

            responseAPI.StatusCode = (int)response.StatusCode;

            return responseAPI;
        }
    }
}
