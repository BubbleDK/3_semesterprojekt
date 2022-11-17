using NetCafeUCN.MVC.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.MVC.Services
{
    public class EmployeeService : INetCafeDataAccess<Employee>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }

        public EmployeeService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        //
        public bool Add(Employee o)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{BaseUri}/{o}", Method.Post)).IsSuccessful;
        }

        public Employee? Get(dynamic key)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{BaseUri}/{key}", Method.Get)).Data;
        }

        public IEnumerable<Employee> GetAll()
        {
            return RestClient.Execute<IEnumerable<Employee>>(new RestRequest($"{BaseUri}"), Method.Get).Data;

        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(Employee o)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{BaseUri}/{0}", Method.Put)).IsSuccessful;
        }


    }
}
