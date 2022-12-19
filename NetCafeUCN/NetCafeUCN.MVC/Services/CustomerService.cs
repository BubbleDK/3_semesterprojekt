using NetCafeUCN.MVC.Models;
using RestSharp;

namespace NetCafeUCN.MVC.Services
{

    public class CustomerService : INetCafeDataAccessService<CustomerDTO>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }

        public CustomerService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        //
        public bool Add(CustomerDTO o)
        {
            var request = new RestRequest($"{BaseUri}", Method.Post);
            request.AddJsonBody(o);
            var response = RestClient.Execute<CustomerDTO>(request);
            var result = response.Content;
            if(result == "false") { return false; }
            return response.IsSuccessStatusCode;
        }

        public CustomerDTO? Get(dynamic key)
        {
            return RestClient.Execute<CustomerDTO>(new RestRequest($"{BaseUri}/{key}", Method.Get)).Data;
        }
        
        public IEnumerable<CustomerDTO> GetAll()
        {
            return RestClient.Execute<IEnumerable<CustomerDTO>>(new RestRequest($"{BaseUri}"), Method.Get).Data;

        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<CustomerDTO>(new RestRequest($"{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(CustomerDTO o)
        {
            return RestClient.Execute<CustomerDTO>(new RestRequest($"{BaseUri}/{0}", Method.Put)).IsSuccessful;
        }


    }
}
