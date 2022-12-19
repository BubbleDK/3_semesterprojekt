using NetCafeUCN.MVC.Models.DTO;
using RestSharp;

namespace NetCafeUCN.MVC.Services
{
    /// <summary>
    /// BookingLineService klasse
    /// </summary>
    public class BookingLineService
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }

        /// <summary>
        /// BookingLineService constructor
        /// </summary>
        /// <param name="baseUri">String af baseUri'en som bruges til at initialisere Rest klienten</param>
        public BookingLineService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }

        /// <summary>
        /// GetAll metode, som henter alle bookinglinjer på en booking
        /// </summary>
        /// <param name="bookingNo">string af booking nummeret</param>
        /// <returns>En collection af BookingLineDto</returns>
        public IEnumerable<BookingLineDTO> GetAll(string bookingNo)
        {
            var request = new RestRequest($"{BaseUri}/{bookingNo}", Method.Get);
            var response = RestClient.Execute<IEnumerable<BookingLineDTO>>(request);
            return response.Data;
            //return RestClient.Execute<IEnumerable<BookingLineDTO>>(new RestRequest($"{BaseUri}{bookingNo}", Method.Get)).Data;
        }
    }
}
