using NetCafeUCN.DesktopApp.DTO;
using RestSharp;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    internal class CustomerService : INetCafeDataAccess<Customer>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public CustomerService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient();
        }
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
            return RestClient.Execute<IEnumerable<Customer>>(new RestRequest()).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<Customer>(new RestRequest($"{BaseUri}/{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(Customer o)
        {
            return RestClient.Execute<Customer>(new RestRequest($"{BaseUri}/{o}", Method.Put)).IsSuccessful;
        }
    }
}
