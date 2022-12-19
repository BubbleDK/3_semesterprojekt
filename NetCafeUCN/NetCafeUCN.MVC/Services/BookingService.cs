using NetCafeUCN.MVC.Models;
using RestSharp;

namespace NetCafeUCN.MVC.Services
{
    /// <summary>
    /// Handles CRUD functionality for objects of type Booking
    /// Uses RestSharp to communicate with Controllers in the API
    /// </summary>
    public class BookingService : INetCafeDataAccessService<BookingDto>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public BookingService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }

        public bool Add(BookingDto o)
        {
            var request = new RestRequest($"{BaseUri}", Method.Post);
            request.AddJsonBody(o);
            var response = RestClient.Execute<BookingDto>(request);
            var result = response.Content;
            if (result == "false") { return false; }
            return response.IsSuccessStatusCode;
            //    return RestClient.Execute<BookingDto>(new RestRequest($"{BaseUri}", Method.Post).AddJsonBody(o)).IsSuccessStatusCode;
        }

        public BookingDto? Get(dynamic key)
        {
            return RestClient.Execute<BookingDto>(new RestRequest($"{BaseUri}/{key}", Method.Get)).Data;
        }

        public IEnumerable<BookingDto> GetAll()
        {
            //var request = new RestRequest($"{BaseUri}");
            //var response = RestClient.Execute<BookingDto>(request);
            //var result = response.Content;
            return RestClient.Execute<IEnumerable<BookingDto>>(new RestRequest()).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<BookingDto>(new RestRequest($"{BaseUri}/{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(BookingDto o)
        {
            return RestClient.Execute<BookingDto>(new RestRequest($"{BaseUri}/{o}", Method.Put)).IsSuccessful;
        }
    }
}
