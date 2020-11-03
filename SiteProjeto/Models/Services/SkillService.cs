using Infrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RestSharp;
using Microsoft.Extensions.Configuration;

namespace SiteProjeto.Models.Services
{
    public class SkillService
    {
        private readonly RestClient client;

        private const string BASE_REQUEST = "skills";

        public SkillService(IConfiguration configuration)
        {
            client = new RestClient(configuration.GetSection("urlAPI").Value);
        }

        public ResponseAPI<List<Skill>> GetAll()
        {
            ResponseAPI<List<Skill>> responseAPI = new ResponseAPI<List<Skill>>();

            var request = new RestRequest(BASE_REQUEST);

            var response = client.Get<List<Skill>>(request);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode == HttpStatusCode.BadRequest)
                ? null
                : JsonConvert.DeserializeObject<List<Skill>>(response.Content);

            return responseAPI;
        }

        public ResponseAPI<Skill> Get(int id)
        {
            ResponseAPI <Skill> responseAPI = new ResponseAPI<Skill>();

            var request = new RestRequest(BASE_REQUEST  + "/{id}")
                .AddUrlSegment("id", id);

            var response = client.Get<Skill>(request);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode != HttpStatusCode.OK)
                ? null
                : JsonConvert.DeserializeObject<Skill>(response.Content);

            return responseAPI;
        }

        public ResponseAPI<int> Post(Skill skill)
        {
            ResponseAPI<int> responseAPI = new ResponseAPI<int>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(skill);

            var response = client.Post<dynamic>(request);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode == HttpStatusCode.BadRequest)
                ? 0
                : JsonConvert.DeserializeObject<dynamic>(response.Content).id;

            return responseAPI;
        }

        public ResponseAPI<object> Put(Skill skill)
        {
            ResponseAPI<object> responseAPI = new ResponseAPI<object>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(skill);

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
