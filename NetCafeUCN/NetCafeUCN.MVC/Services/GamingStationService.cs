using NetCafeUCN.MVC.Models;
using RestSharp;

namespace NetCafeUCN.MVC.Services
{

    public class GamingstationService : INetCafeDataAccessService<GamingStationDTO>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public GamingstationService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        
        public bool Add(GamingStationDTO o)
        {
            return RestClient.Execute<GamingStationDTO>(new RestRequest($"{BaseUri}/{o}", Method.Post)).IsSuccessful;
        }

        public GamingStationDTO? Get(dynamic key)
        {
            return RestClient.Execute<GamingStationDTO>(new RestRequest($"{BaseUri}/{key}",Method.Get)).Data;
        }
        public IEnumerable<GamingStationDTO> GetAll()
        {
            return RestClient.Execute<IEnumerable<GamingStationDTO>>(new RestRequest($"{BaseUri}"), Method.Get).Data;
        }
        public bool Remove(dynamic key)
        {
            return RestClient.Execute<GamingStationDTO>(new RestRequest($"{BaseUri}/{key}", Method.Delete)).IsSuccessful;
        }
        
        public bool Update(GamingStationDTO o)
        {
            return RestClient.Execute<GamingStationDTO>(new RestRequest($"{BaseUri}/", Method.Put).AddJsonBody(o)).IsSuccessful;
            //return RestClient.Execute<GamingStationDto>(new RestRequest($"{BaseUri}/{o}",Method.Put)).IsSuccessful;
        }
    }
}
