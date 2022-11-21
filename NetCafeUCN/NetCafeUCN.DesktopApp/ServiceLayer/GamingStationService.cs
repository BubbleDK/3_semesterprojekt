using NetCafeUCN.DesktopApp.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    public class GamingStationService : INetCafeDataAccess<GamingStationDTO>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public GamingStationService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        public bool Add(GamingStationDTO o)
        {
            return RestClient.Execute<GamingStationDTO>(new RestRequest($"{BaseUri}", Method.Post).AddJsonBody(o)).IsSuccessful;
        }

        public GamingStationDTO? Get(dynamic key)
        {
            return RestClient.Execute<GamingStationDTO>(new RestRequest($"{BaseUri}{key}", Method.Get)).Data;
        }

        public IEnumerable<GamingStationDTO> GetAll()
        {
            return RestClient.Execute<IEnumerable<GamingStationDTO>>(new RestRequest($"{BaseUri}",Method.Get)).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<GamingStationDTO>(new RestRequest($"{BaseUri}{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(GamingStationDTO o)
        {
            return RestClient.Execute<GamingStationDTO>(new RestRequest($"{BaseUri}", Method.Put).AddJsonBody(o)).IsSuccessful;
        }
    }
}
