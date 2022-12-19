using NetCafeUCN.MVC.Models;
using RestSharp;

namespace NetCafeUCN.MVC.Services
{

    public class CustomerService : INetCafeDataAccessService<CustomerDto>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }

        public CustomerService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        //
        public bool Add(CustomerDto o)
        {
            var request = new RestRequest($"{BaseUri}", Method.Post);
            request.AddJsonBody(o);
            var response = RestClient.Execute<CustomerDto>(request);
            var result = response.Content;
            if(result == "false") { return false; }
            return response.IsSuccessStatusCode;
        }

        public CustomerDto? Get(dynamic key)
        {
            return RestClient.Execute<CustomerDto>(new RestRequest($"{BaseUri}/{key}", Method.Get)).Data;
        }
        
        public IEnumerable<CustomerDto> GetAll()
        {
            return RestClient.Execute<IEnumerable<CustomerDto>>(new RestRequest($"{BaseUri}"), Method.Get).Data;

        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<CustomerDto>(new RestRequest($"{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(CustomerDto o)
        {
            return RestClient.Execute<CustomerDto>(new RestRequest($"{BaseUri}/{0}", Method.Put)).IsSuccessful;
        }


    }
}
