using NetCafeUCN.DesktopApp.DTO;
using RestSharp;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    public class ConsumableService : INetCafeDataAccess<ConsumableDTO>
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
            
            return RestClient.Execute<ConsumableDTO>(new RestRequest($"{BaseUri}", Method.Post).AddJsonBody(o)).IsSuccessful;
        }

        public ConsumableDTO? Get(dynamic key)
        {
            return RestClient.Execute<ConsumableDTO>(new RestRequest($"{BaseUri}{key}", Method.Get)).Data;
        }

        public IEnumerable<ConsumableDTO> GetAll()
        {
            return RestClient.Execute<IEnumerable<ConsumableDTO>>(new RestRequest($"{BaseUri}",Method.Get)).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<ConsumableDTO>(new RestRequest($"{BaseUri}{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(ConsumableDTO o)
        {

            return RestClient.Execute<ConsumableDTO>(new RestRequest($"{BaseUri}", Method.Put).AddJsonBody(o)).IsSuccessful;
        }
    }
}
