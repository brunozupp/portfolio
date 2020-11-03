using Infrastructure.DTOs;
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
    public class DetailService
    {
        private readonly RestClient client;

        private const string BASE_REQUEST = "details";

        public DetailService(IConfiguration configuration)
        {
            client = new RestClient(configuration.GetSection("urlAPI").Value);
        }

        public async Task<ResponseAPI<Detail>> Get()
        {
            ResponseAPI<Detail> responseAPI = new ResponseAPI<Detail>();

            var request = new RestRequest(BASE_REQUEST);

            var response = await client.ExecuteAsync<Detail>(request, Method.GET);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode != HttpStatusCode.OK)
                ? null
                : JsonConvert.DeserializeObject<Detail>(response.Content);

            return responseAPI;
        }

        public async Task<ResponseAPI<DetailsDTO>> GetPortfolio()
        {
            ResponseAPI<DetailsDTO> responseAPI = new ResponseAPI<DetailsDTO>();

            var request = new RestRequest(BASE_REQUEST + "/getPortfolio");

            var response = await client.ExecuteAsync<Detail>(request, Method.GET);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode != HttpStatusCode.OK)
                ? null
                : JsonConvert.DeserializeObject<DetailsDTO>(response.Content);

            return responseAPI;
        }

        public async Task<ResponseAPI<int>> Post(Detail detail)
        {
            ResponseAPI<int> responseAPI = new ResponseAPI<int>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(detail);

            var response = await client.ExecuteAsync<dynamic>(request, Method.POST);

            responseAPI.StatusCode = (int)response.StatusCode;

            responseAPI.Content = (response.StatusCode != HttpStatusCode.OK)
                ? 0
                : JsonConvert.DeserializeObject<dynamic>(response.Content).id;

            return responseAPI;
        }

        public async Task<ResponseAPI<object>> Put(Detail detail)
        {
            ResponseAPI<object> responseAPI = new ResponseAPI<object>();

            var request = new RestRequest(BASE_REQUEST).AddJsonBody(detail);

            var response = await client.ExecuteAsync(request, Method.PUT);

            responseAPI.StatusCode = (int)response.StatusCode;

            return responseAPI;
        }
    }
}
