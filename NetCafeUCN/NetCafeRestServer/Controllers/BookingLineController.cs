using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingLineController : ControllerBase
    {

        private INetCafeUCNBookingLineDAO dataAccess;

        public BookingLineController(INetCafeUCNBookingLineDAO dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        // GET: api/<BookingLineController>
        [HttpGet]
        [Route("{bookingNo}")]
        public ActionResult<IEnumerable<BookingLineDTO>> GetAll(string bookingNo)
        {
            return Ok(dataAccess.GetBookingLinesByBooking(bookingNo).BookingLineToDtos());
        }
    }
}
