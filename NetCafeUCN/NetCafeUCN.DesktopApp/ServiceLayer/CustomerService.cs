using NetCafeUCN.DesktopApp.DTO;
using RestSharp;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    /// <summary>
    /// Handles CRUD functionality for objects of type Customer
    /// Uses RestSharp to communicate with Controllers in the API
    /// </summary>
    internal class CustomerService : INetCafeDataAccess<CustomerDTO>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public CustomerService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        public bool Add(CustomerDTO o)
        {
            return RestClient.Execute<CustomerDTO>(new RestRequest($"{BaseUri}", Method.Post).AddJsonBody(o)).IsSuccessful;
        }

        public CustomerDTO? Get(dynamic key)
        {
            return RestClient.Execute<CustomerDTO>(new RestRequest($"{BaseUri}{key}", Method.Get)).Data;
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            return RestClient.Execute<IEnumerable<CustomerDTO>>(new RestRequest($"{BaseUri}", Method.Get)).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<CustomerDTO>(new RestRequest($"{BaseUri}{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(CustomerDTO o)
        {
            return RestClient.Execute<CustomerDTO>(new RestRequest($"{BaseUri}", Method.Put).AddJsonBody(o)).IsSuccessful;
        }
    }
}
