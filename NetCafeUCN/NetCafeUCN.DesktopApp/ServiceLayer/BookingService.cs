using NetCafeUCN.DesktopApp.DTO;
using RestSharp;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    /// <summary>
    /// Handles CRUD functionality for objects of type Booking
    /// Uses RestSharp to communicate with Controllers in the API
    /// </summary>
    public class BookingService : INetCafeDataAccess<BookingDTO>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public BookingService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        
        public bool Add(BookingDTO o)
        {
            var request = new RestRequest($"{BaseUri}", Method.Post);
            request.AddJsonBody(o);
            var response = RestClient.Execute<BookingDTO>(request);
            var result = response.Content;
            if (result == "false") { return false; }
            return response.IsSuccessStatusCode;
        }

        public BookingDTO? Get(dynamic key)
        {
            return RestClient.Execute<BookingDTO>(new RestRequest($"{BaseUri}{key}", Method.Get)).Data;
        }

        public IEnumerable<BookingDTO> GetAll()
        {
            //var request = new RestRequest($"{BaseUri}");
            //var response = RestClient.Execute<BookingDTO>(request);
            //var result = response.Content;
            return RestClient.Execute<IEnumerable<BookingDTO>>(new RestRequest()).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<BookingDTO>(new RestRequest($"{BaseUri}{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(BookingDTO o)
        {
            return RestClient.Execute<BookingDTO>(new RestRequest($"{BaseUri}{o}", Method.Put)).IsSuccessful;
        }
    }
}
