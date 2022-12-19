using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    /// <summary>
    ///  API Controller for Booking, som implementere ControllerBase
    /// </summary>
    [Route("bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly INetCafeDAO<Booking> dataAccess;

        /// <summary>
        ///  BookingController constructor
        /// </summary>
        /// <param name="dataAccess">Model som skal sættes for controlleren</param>
        public BookingController(INetCafeDAO<Booking> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        // GET: api/<BookingController>
        /// <summary>
        ///  Henter alle bookinger
        /// </summary>
        /// <returns>Returnere en collection af Bookinger</returns>
        [HttpGet]
        public ActionResult <IEnumerable<BookingDTO>> Get()
        {
            return Ok(dataAccess.GetAll().BookingToDtos());
        }

        // GET api/<BookingController>/5
        /// <summary>
        ///  Henter en bestemt booking
        /// </summary>
        /// <param name="bookingNo">booking nummer på den bestemte booking</param>
        /// <returns>Returnere den bestemte booking eller 404 status kode hvis den ikke blev fundet</returns>
        [HttpGet]
        [Route("{bookingNo}")]
        public ActionResult<BookingDTO> Get(string bookingNo)
        {
            var booking = dataAccess.Get(bookingNo).BookingToDto();
            if (booking == null) { return NotFound(); }
            return Ok(booking);
        }

        // POST api/<BookingController>
        /// <summary>
        ///  Opretter en ny booking
        /// </summary>
        /// <param name="bookingdto">Objekt af en booking</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] BookingDTO bookingdto)
        {
            return Ok(dataAccess.Add(bookingdto.BookingFromDto()));
        }

        // PUT api/<BookingController>/5
        /// <summary>
        ///  Opdatere en booking
        /// </summary>
        /// <param name="bookingdto">Objekt af en booking</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPut]
        public ActionResult<bool> Update(BookingDTO bookingdto)
        {
            return Ok(dataAccess.Add(bookingdto.BookingFromDto()));
        }

        // DELETE api/<BookingController>/5
        /// <summary>
        ///  Sletter en booking
        /// </summary>
        /// <param name="bookingNo">Booking nummer på den booking der skal slettes</param>
        /// <returns>Returnere status kode 200 hvis den blev fjernet, eller 404 status kode hvis den ikke blev fundet</returns>
        [HttpDelete("{bookingNo}")]
        public ActionResult<bool> Delete(string bookingNo)
        {
            if (dataAccess.Remove(bookingNo))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
