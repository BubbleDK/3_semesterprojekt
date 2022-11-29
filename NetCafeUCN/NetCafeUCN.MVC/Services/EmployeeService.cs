using Microsoft.AspNetCore.Authorization;
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
    
    public class EmployeeService : INetCafeDataAccessService<EmployeeDto>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }

        public EmployeeService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        
        public bool Add(EmployeeDto o)
        {
            return RestClient.Execute<EmployeeDto>(new RestRequest($"{BaseUri}/{o}", Method.Post)).IsSuccessful;
        }

        public EmployeeDto? Get(dynamic key)
        {
            return RestClient.Execute<EmployeeDto>(new RestRequest($"{BaseUri}/{key}", Method.Get)).Data;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            return RestClient.Execute<IEnumerable<EmployeeDto>>(new RestRequest($"{BaseUri}"), Method.Get).Data;

        }
        
        public bool Remove(dynamic key)
        {
            return RestClient.Execute<EmployeeDto>(new RestRequest($"{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(EmployeeDto o)
        {
            return RestClient.Execute<EmployeeDto>(new RestRequest($"{BaseUri}/{0}", Method.Put)).IsSuccessful;
        }


    }
}
