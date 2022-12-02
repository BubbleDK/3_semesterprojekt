using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingLineController : ControllerBase
    {

        private BookingLineDAO dataAccess;

        public BookingLineController(BookingLineDAO dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        // GET: api/<BookingLineController>
        [HttpGet("{bookingno}")]
        public ActionResult<IEnumerable<BookingLine>> GetAll(string bookingNo)
        {
            return Ok(dataAccess.GetBookingLinesByBooking(bookingNo));
        }

        // GET api/<BookingLineController>/5
        [HttpGet]
        public string GetAll()
        {
            return "value";
        }

        // POST api/<BookingLineController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookingLineController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingLineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
