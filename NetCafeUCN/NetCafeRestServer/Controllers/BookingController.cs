using DataAccessLayer.DAO;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;



namespace NetCafeRestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private INetCafeDataAccess<Booking> dataAccess;
        // GET: api/<BookingController>
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return Ok(dataAccess.GetAll());
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
