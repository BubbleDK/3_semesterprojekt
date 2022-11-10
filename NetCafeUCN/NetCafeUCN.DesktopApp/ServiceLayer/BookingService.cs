using NetCafeUCN.DesktopApp.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
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
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(dynamic key)
        {
            throw new NotImplementedException();
        }

        public bool Update(Booking o)
        {
            throw new NotImplementedException();
        }
    }
}
