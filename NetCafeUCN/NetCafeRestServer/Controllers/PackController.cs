using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackController : ControllerBase
    {
        private INetCafeDAO<Pack> dataAccess;
        public PackController(INetCafeDAO<Pack> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        // GET: api/<PackController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PackController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PackController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Pack o)
        {
            return Ok(dataAccess.Add(o));
        }

        // PUT api/<PackController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PackController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
