using Microsoft.AspNetCore.Authorization;
using NetCafeUCN.MVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.MVC.Services
{
    
    public class ConsumableService : INetCafeDataAccessService<ConsumableDto>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public ConsumableService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        public bool Add(ConsumableDto o)
        {
            return RestClient.Execute<ConsumableDto>(new RestRequest($"{BaseUri}/{o}", Method.Post)).IsSuccessful;
        }

        public ConsumableDto? Get(dynamic key)
        {
            return RestClient.Execute<ConsumableDto>(new RestRequest($"{BaseUri}/{key}",Method.Get)).Data;
        }
        
        public IEnumerable<ConsumableDto> GetAll()
        {
            return RestClient.Execute<IEnumerable<ConsumableDto>>(new RestRequest($"{BaseUri}"), Method.Get).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<ConsumableDto?>(new RestRequest($"{BaseUri}/{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(ConsumableDto o)
        {
            return RestClient.Execute<ConsumableDto>(new RestRequest($"{BaseUri}/{o}",Method.Put)).IsSuccessful;
        }
    }
}
