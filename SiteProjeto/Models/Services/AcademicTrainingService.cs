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
    public class AcademicTrainingService
    {
        private readonly RestClient client;

        private const string BASE_REQUEST = "academictrainings";

        public AcademicTrainingService(IConfiguration configuration)
        {
            client = new RestClient(configuration.GetSection("urlAPI").Value);
        }

        public ResponseAPI<List<AcademicTraining>> GetAll()
        {
            ResponseAPI<List<AcademicTraining>> responseAPI = new ResponseAPI<List<AcademicTraining>>();

            var request = new RestRequest(BASE_REQUEST);

            var response = client.Get<List<AcademicTraining>>(request);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode == HttpStatusCode.BadRequest)
                ? null
                : JsonConvert.DeserializeObject<List<AcademicTraining>>(response.Content);

            return responseAPI;
        }

        public ResponseAPI<AcademicTraining> Get(int id)
        {
            ResponseAPI<AcademicTraining> responseAPI = new ResponseAPI<AcademicTraining>();

            var request = new RestRequest(BASE_REQUEST + "/{id}")
                .AddUrlSegment("id", id);

            var response = client.Get<AcademicTraining>(request);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode != HttpStatusCode.OK)
                ? null
                : JsonConvert.DeserializeObject<AcademicTraining>(response.Content);

            return responseAPI;
        }

        public ResponseAPI<int> Post(AcademicTraining academicTraining)
        {
            ResponseAPI<int> responseAPI = new ResponseAPI<int>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(academicTraining);

            var response = client.Post<dynamic>(request);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode == HttpStatusCode.BadRequest)
                ? 0
                : JsonConvert.DeserializeObject<dynamic>(response.Content).id;

            return responseAPI;
        }

        public ResponseAPI<object> Put(AcademicTraining academicTraining)
        {
            ResponseAPI<object> responseAPI = new ResponseAPI<object>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(academicTraining);

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
