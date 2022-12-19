using NetCafeUCN.MVC.Models;
using RestSharp;

namespace NetCafeUCN.MVC.Services
{

    public class EmployeeService : INetCafeDataAccessService<EmployeeDTO>
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
            return RestClient.Execute<EmployeeDTO>(new RestRequest($"{BaseUri}/{o}", Method.Post)).IsSuccessful;
        }

        public EmployeeDTO? Get(dynamic key)
        {
            return RestClient.Execute<EmployeeDTO>(new RestRequest($"{BaseUri}/{key}", Method.Get)).Data;
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            return RestClient.Execute<IEnumerable<EmployeeDTO>>(new RestRequest($"{BaseUri}"), Method.Get).Data;

        }
        
        public bool Remove(dynamic key)
        {
            return RestClient.Execute<EmployeeDTO>(new RestRequest($"{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(EmployeeDTO o)
        {
            return RestClient.Execute<EmployeeDTO>(new RestRequest($"{BaseUri}/{0}", Method.Put)).IsSuccessful;
        }


    }
}
