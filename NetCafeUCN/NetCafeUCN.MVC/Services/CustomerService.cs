using Microsoft.AspNetCore.Authorization;
using NetCafeUCN.MVC.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.MVC.Services
{
    
    public class CustomerService : INetCafeDataAccessService<CustomerDto>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }

        public CustomerService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        //
        public bool Add(CustomerDto o)
        {
            return RestClient.Execute<CustomerDto>(new RestRequest($"{BaseUri}", Method.Post).AddJsonBody(o)).IsSuccessful;

        }

        public CustomerDto? Get(dynamic key)
        {
            return RestClient.Execute<CustomerDto>(new RestRequest($"{BaseUri}/{key}", Method.Get)).Data;
        }
        
        public IEnumerable<CustomerDto> GetAll()
        {
            return RestClient.Execute<IEnumerable<CustomerDto>>(new RestRequest($"{BaseUri}"), Method.Get).Data;

        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<CustomerDto>(new RestRequest($"{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(CustomerDto o)
        {
            return RestClient.Execute<CustomerDto>(new RestRequest($"{BaseUri}/{0}", Method.Put)).IsSuccessful;
        }


    }
}
