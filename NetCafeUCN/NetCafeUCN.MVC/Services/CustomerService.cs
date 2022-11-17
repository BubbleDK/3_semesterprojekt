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
    public class CustomerService : INetCafeDataAccess<Customer>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }

        public CustomerService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        //
        public bool Add(Customer o)
        {
            return RestClient.Execute<Customer>(new RestRequest($"{BaseUri}/{o}", Method.Post)).IsSuccessful;
        }

        public Customer? Get(dynamic key)
        {
            return RestClient.Execute<Customer>(new RestRequest($"{BaseUri}/{key}", Method.Get)).Data;
        }

        public IEnumerable<Customer> GetAll()
        {
            return RestClient.Execute<IEnumerable<Customer>>(new RestRequest($"{BaseUri}"), Method.Get).Data;

        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<Customer>(new RestRequest($"{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(Customer o)
        {
            return RestClient.Execute<Customer>(new RestRequest($"{BaseUri}/{0}", Method.Put)).IsSuccessful;
        }


    }
}
