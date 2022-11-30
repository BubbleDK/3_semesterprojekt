﻿using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private INetCafeDAO<Booking> dataAccess;

        public BookingController(INetCafeDAO<Booking> dataAccess)
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
        public ActionResult<Booking> Get(string bookingNo)
        {
            var booking = dataAccess.Get(bookingNo);
            if (booking == null) { return NotFound(); }
            return Ok(booking);
        }

        // POST api/<BookingController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Booking bookingdto)
        {
            //Booking booking = bookingdto.BookingFromDto();
            return Ok(dataAccess.Add(bookingdto));
        }

        // PUT api/<BookingController>/5
        [HttpPut]
        public ActionResult<bool> Update(Booking bookingdto)
        {
            //Booking booking = bookingdto.BookingFromDto();
            return Ok(dataAccess.Update(bookingdto));
        }

        // DELETE api/<BookingController>/5
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
