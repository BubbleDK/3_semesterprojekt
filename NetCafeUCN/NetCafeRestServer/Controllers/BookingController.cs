using DataAccessLayer.DAO;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace NetCafeRestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private INetCafeDataAccess<Booking> dataAccess;

        public BookingController(INetCafeDataAccess<Booking> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        // GET: api/<BookingController>
        [HttpGet]
        public ActionResult <IEnumerable<Booking>> Get()
        {
            return Ok(dataAccess.GetAll());
        }

        // GET api/<BookingController>/5
        [HttpGet]
        [Route("{bookingNo}")]
        public ActionResult<Booking> Get(int bookingNo)
        {
            var booking = dataAccess.Get(bookingNo);
            if (booking == null) { return NotFound(); }
            return Ok(booking);
        }

        // POST api/<BookingController>
        [HttpPost]
        public ActionResult<int> Add(Booking booking)
        {
            return Ok(dataAccess.Add(booking));
        }

        // PUT api/<BookingController>/5
        [HttpPut]
        public ActionResult<bool> Update(Booking booking)
        {
            return Ok(dataAccess.Update(booking));
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{bookingNo}")]
        public ActionResult<bool> Delete(int bookingNo)
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
