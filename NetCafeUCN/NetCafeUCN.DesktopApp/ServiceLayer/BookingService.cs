using NetCafeUCN.DesktopApp.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    /// <summary>
    /// Handles CRUD functionality for objects of type Booking
    /// Uses RestSharp to communicate with Controllers in the API
    /// </summary>
    public class BookingService : INetCafeDataAccess<Booking>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public BookingService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient();
        }
        
        public bool Add(Booking o)
        {
            return RestClient.Execute<Booking>(new RestRequest($"{BaseUri}{0}", Method.Post)).IsSuccessful;
        }

        public Booking? Get(dynamic key)
        {
            return RestClient.Execute<Booking>(new RestRequest($"{BaseUri}{key}", Method.Get)).Data;
        }

        public IEnumerable<Booking> GetAll()
        {
            return RestClient.Execute<IEnumerable<Booking>>(new RestRequest()).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<Booking>(new RestRequest($"{BaseUri}{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(Booking o)
        {
            return RestClient.Execute<Booking>(new RestRequest($"{BaseUri}{o}", Method.Put)).IsSuccessful;
        }
    }
}
