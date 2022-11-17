﻿using NetCafeUCN.DesktopApp.DTO;
using RestSharp;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    /// <summary>
    /// Handles CRUD functionality for objects of type Employee
    /// Uses RestSharp to communicate with Controllers in the API
    /// </summary>
    internal class EmployeeService : INetCafeDataAccess<Employee>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public EmployeeService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        public bool Add(Employee o)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{BaseUri}{o}",Method.Post)).IsSuccessful;
        }

        public Employee? Get(dynamic key)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{BaseUri}{key}",Method.Get)).Data;
        }

        public IEnumerable<Employee> GetAll()
        {
            return RestClient.Execute<IEnumerable<Employee>>(new RestRequest()).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{BaseUri}{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(Employee o)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{BaseUri}{o}",Method.Put)).IsSuccessful;
        }
    }
}
