using NetCafeUCN;
using NetCafeUCN.MVC.Models.DTO;
using RestSharp;

namespace NetCafeUCN.MVC.Services
{
    public class BookingLineService
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public BookingLineService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }

        public IEnumerable<BookingLineDto> GetAll(string bookingNo)
        {
            var request = new RestRequest($"{BaseUri}/{bookingNo}", Method.Get);
            var response = RestClient.Execute<IEnumerable<BookingLineDto>>(request);
            return response.Data;
            //return RestClient.Execute<IEnumerable<BookingLineDTO>>(new RestRequest($"{BaseUri}{bookingNo}", Method.Get)).Data;
        }
    }
}
