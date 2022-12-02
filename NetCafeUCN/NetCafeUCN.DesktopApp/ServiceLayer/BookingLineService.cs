using NetCafeUCN.DAL.DAO;
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
    public class BookingLineService : BookingLineDAO
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public BookingLineService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }

        public IEnumerable<BookingLineDTO> GetAll(string bookingNo)
        {
            var request = new RestRequest($"{BaseUri}{bookingNo}", Method.Get);
            var response = RestClient.Execute<IEnumerable<BookingLineDTO>>(request);
            var result = response.Content;
            return response.Data;
            //return RestClient.Execute<IEnumerable<BookingLineDTO>>(new RestRequest($"{BaseUri}{bookingNo}", Method.Get)).Data;
        }
    }
}
