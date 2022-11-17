using NetCafeUCN.DesktopApp.DTO;
using RestSharp;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    /// <summary>
    /// Handles CRUD functionality for objects of type Customer
    /// Uses RestSharp to communicate with Controllers in the API
    /// </summary>
    internal class CustomerService : INetCafeDataAccess<Customer>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public CustomerService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        public bool Add(Customer o)
        {
            return RestClient.Execute<Customer>(new RestRequest($"{BaseUri}", Method.Post).AddJsonBody(o)).IsSuccessful;
        }

        public Customer? Get(dynamic key)
        {
            return RestClient.Execute<Customer>(new RestRequest($"{BaseUri}{key}", Method.Get)).Data;
        }

        public IEnumerable<Customer> GetAll()
        {
            return RestClient.Execute<IEnumerable<Customer>>(new RestRequest()).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<Customer>(new RestRequest($"{BaseUri}{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(Customer o)
        {
            return RestClient.Execute<Customer>(new RestRequest($"{BaseUri}", Method.Put).AddJsonBody(o)).IsSuccessful;
        }
    }
}
