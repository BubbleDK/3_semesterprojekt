using NetCafeUCN.DesktopApp.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    public class ConsumableService : INetCafeDataAccess<Consumable>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public ConsumableService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        public bool Add(Consumable o)
        {
            return RestClient.Execute<Consumable>(new RestRequest($"{BaseUri}{o}", Method.Post)).IsSuccessful;
        }

        public Consumable? Get(dynamic key)
        {
            return RestClient.Execute<Consumable>(new RestRequest($"{BaseUri}{key}", Method.Get)).Data;
        }

        public IEnumerable<Consumable> GetAll()
        {
            return RestClient.Execute<IEnumerable<Consumable>>(new RestRequest($"{BaseUri}",Method.Get)).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<Consumable>(new RestRequest($"{BaseUri}{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(Consumable o)
        {
            return RestClient.Execute<Consumable>(new RestRequest($"{BaseUri}{o}", Method.Put)).IsSuccessful;
        }
    }
}
