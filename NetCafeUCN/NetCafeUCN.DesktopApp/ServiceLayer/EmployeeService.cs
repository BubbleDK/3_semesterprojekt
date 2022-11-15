using NetCafeUCN.DesktopApp.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    internal class EmployeeService : INetCafeDataAccess<Employee>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public EmployeeService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient();
        }
        public bool Add(Employee o)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{BaseUri}/{o}",Method.Post)).IsSuccessful;
        }

        public Employee? Get(dynamic key)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{BaseUri}/{key}",Method.Get)).Data;
        }

        public IEnumerable<Employee> GetAll()
        {
            return RestClient.Execute<IEnumerable<Employee>>(new RestRequest()).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{BaseUri}/{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(Employee o)
        {
            return RestClient.Execute<Employee>(new RestRequest($"{BaseUri}/{o}",Method.Put)).IsSuccessful;
        }
    }
}
