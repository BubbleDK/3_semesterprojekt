using NetCafeUCN.MVC.Models;
using RestSharp;

namespace NetCafeUCN.MVC.Services
{

    public class ConsumableService : INetCafeDataAccessService<ConsumableDTO>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public ConsumableService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        public bool Add(ConsumableDTO o)
        {
            return RestClient.Execute<ConsumableDTO>(new RestRequest($"{BaseUri}/{o}", Method.Post)).IsSuccessful;
        }

        public ConsumableDTO? Get(dynamic key)
        {
            return RestClient.Execute<ConsumableDTO>(new RestRequest($"{BaseUri}/{key}",Method.Get)).Data;
        }
        
        public IEnumerable<ConsumableDTO> GetAll()
        {
            return RestClient.Execute<IEnumerable<ConsumableDTO>>(new RestRequest($"{BaseUri}"), Method.Get).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<ConsumableDTO?>(new RestRequest($"{BaseUri}/{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(ConsumableDTO o)
        {
            return RestClient.Execute<ConsumableDTO>(new RestRequest($"{BaseUri}/{o}",Method.Put)).IsSuccessful;
        }
    }
}
