using NetCafeUCN.DesktopApp.DTO;
using RestSharp;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    /// <summary>
    /// Handles CRUD functionality for objects of type Employee
    /// Uses RestSharp to communicate with Controllers in the API
    /// </summary>
    internal class EmployeeService : INetCafeDataAccess<EmployeeDTO>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public EmployeeService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        public bool Add(EmployeeDTO o)
        {
            return RestClient.Execute<EmployeeDTO>(new RestRequest($"{BaseUri}{o}",Method.Post).AddJsonBody(o)).IsSuccessful;
        }

        public EmployeeDTO? Get(dynamic key)
        {
            return RestClient.Execute<EmployeeDTO>(new RestRequest($"{BaseUri}{key}",Method.Get)).Data;
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            return RestClient.Execute<IEnumerable<EmployeeDTO>>(new RestRequest($"{BaseUri}", Method.Get)).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<EmployeeDTO>(new RestRequest($"{BaseUri}{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(EmployeeDTO o)
        {
            return RestClient.Execute<EmployeeDTO>(new RestRequest($"{BaseUri}",Method.Put).AddJsonBody(o)).IsSuccessful;
        }
    }
}
