using NetCafeUCN.MVC.Models;
using RestSharp;

namespace NetCafeUCN.MVC.Services
{

    public class GamingstationService : INetCafeDataAccessService<GamingStationDto>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public GamingstationService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        
        public bool Add(GamingStationDto o)
        {
            return RestClient.Execute<GamingStationDto>(new RestRequest($"{BaseUri}/{o}", Method.Post)).IsSuccessful;
        }

        public GamingStationDto? Get(dynamic key)
        {
            return RestClient.Execute<GamingStationDto>(new RestRequest($"{BaseUri}/{key}",Method.Get)).Data;
        }
        public IEnumerable<GamingStationDto> GetAll()
        {
            return RestClient.Execute<IEnumerable<GamingStationDto>>(new RestRequest($"{BaseUri}"), Method.Get).Data;
        }
        public bool Remove(dynamic key)
        {
            return RestClient.Execute<GamingStationDto>(new RestRequest($"{BaseUri}/{key}", Method.Delete)).IsSuccessful;
        }
        
        public bool Update(GamingStationDto o)
        {
            return RestClient.Execute<GamingStationDto>(new RestRequest($"{BaseUri}/", Method.Put).AddJsonBody(o)).IsSuccessful;
            //return RestClient.Execute<GamingStationDto>(new RestRequest($"{BaseUri}/{o}",Method.Put)).IsSuccessful;
        }
    }
}
