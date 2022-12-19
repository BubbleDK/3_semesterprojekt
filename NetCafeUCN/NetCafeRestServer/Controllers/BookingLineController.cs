using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCafeUCN.API.Controllers
{
    /// <summary>
    ///  API Controller for BookingLine, som implementere ControllerBase
    /// </summary>
    [Route("bookinglines")]
    [ApiController]
    public class BookingLineController : ControllerBase
    {

        private readonly INetCafeUCNBookingLineDAO dataAccess;

        /// <summary>
        ///  BookingLineController constructor
        /// </summary>
        /// <param name="dataAccess">Model som skal sættes for controlleren</param>
        public BookingLineController(INetCafeUCNBookingLineDAO dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        // GET: api/<BookingLineController>
        /// <summary>
        ///  Henter alle bookinger linjer
        /// </summary>
        /// <param name="bookingNo">booking nummer på den bestemte booking</param>
        /// <returns>Returnere en collection af Bookingerlinjer</returns>
        [HttpGet]
        [Route("{bookingNo}")]
        public ActionResult<IEnumerable<BookingLineDTO>> GetAll(string bookingNo)
        {
            return Ok(dataAccess.GetBookingLinesByBooking(bookingNo).BookingLineToDtos());
        }
    }
}
