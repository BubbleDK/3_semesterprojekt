using NetCafeUCN.DesktopApp.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    internal class GamingStationService : INetCafeDataAccess<GamingStation>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public GamingStationService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient();
        }
        public bool Add(GamingStation o)
        {
            throw new NotImplementedException();
        }

        public GamingStation? Get(dynamic key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GamingStation> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(dynamic key)
        {
            throw new NotImplementedException();
        }

        public bool Update(GamingStation o)
        {
            throw new NotImplementedException();
        }
    }
}
