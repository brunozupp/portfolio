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
    public class ExperienceService
    {
        private readonly RestClient client;

        private const string BASE_REQUEST = "experiences";

        public ExperienceService(IConfiguration configuration)
        {
            client = new RestClient(configuration.GetSection("urlAPI").Value);
        }

        public async Task<ResponseAPI<List<Experience>>> GetAll()
        {
            ResponseAPI<List<Experience>> responseAPI = new ResponseAPI<List<Experience>>();

            var request = new RestRequest(BASE_REQUEST);

            var response = await client.ExecuteAsync<List<Experience>>(request, Method.GET);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode == HttpStatusCode.BadRequest)
                ? null
                : response.Data;

            return responseAPI;
        }

        public async Task<ResponseAPI<Experience>> Get(int id)
        {
            ResponseAPI<Experience> responseAPI = new ResponseAPI<Experience>();

            var request = new RestRequest(BASE_REQUEST + "/{id}")
                .AddUrlSegment("id", id);

            var response = await client.ExecuteAsync<Experience>(request, Method.GET);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode != HttpStatusCode.OK)
                ? null
                : JsonConvert.DeserializeObject<Experience>(response.Content);

            return responseAPI;
        }

        public async Task<ResponseAPI<int>> Post(Experience experience)
        {
            ResponseAPI<int> responseAPI = new ResponseAPI<int>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(experience);

            var response = await client.ExecuteAsync<dynamic>(request, Method.POST);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode == HttpStatusCode.BadRequest)
                ? 0
                : JsonConvert.DeserializeObject<dynamic>(response.Content).id;

            return responseAPI;
        }

        public async Task<ResponseAPI<object>> Put(Experience experience)
        {
            ResponseAPI<object> responseAPI = new ResponseAPI<object>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(experience);

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
