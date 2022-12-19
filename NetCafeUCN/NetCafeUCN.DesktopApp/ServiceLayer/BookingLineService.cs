using NetCafeUCN.DesktopApp.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    public class BookingLineService
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        /// <summary>
        /// Constructor til denne service
        /// </summary>
        /// <param name="baseUri">Uri strengen til der hvor service skal request</param>
        public BookingLineService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }

        /// <summary>
        /// Metoden til at hente alle bookinglines på en given booking
        /// </summary>
        /// <param name="bookingNo">Bookingnummeret på den booking man ønsker at hente bookingslines fra</param>
        /// <returns>En samling af bookinglinjer som ligger på den booking der er forespurgt</returns>
        public IEnumerable<BookingLineDTO> GetAll(string bookingNo)
        {
            var request = new RestRequest($"{BaseUri}{bookingNo}", Method.Get);
            var response = RestClient.Execute<IEnumerable<BookingLineDTO>>(request);
            var result = response.Content;
            return response.Data;
        }
    }
}