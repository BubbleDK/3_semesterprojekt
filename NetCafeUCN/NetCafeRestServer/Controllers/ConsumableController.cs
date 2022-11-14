using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumableController : ControllerBase
    {
        private INetCafeDataAccess<Consumable> dataAccess;


        public ConsumableController(INetCafeDataAccess<Consumable> dataAccess)
        {
            this.dataAccess = dataAccess;

        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Consumable>> GetAll()
        {
            return Ok(dataAccess.GetAll());
        }

        // GET api/<ProductController>/74747
        [HttpGet]
        [Route("{productNo}")]
        public ActionResult<Consumable> Get(string productNo)
        {
            var product = dataAccess.Get(productNo);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Consumable p)
        {
            return Ok(dataAccess.Add(p));
        }

        // PUT api/<ProductController>/
        [HttpPut]
        public ActionResult<bool> Update(Consumable product)
        {
            return Ok(dataAccess.Update(product));
        }

        // DELETE api/<ProductController>/40559810
        [HttpDelete("{productNo}")]
        public ActionResult<bool> Delete(string productNo)
        {
            if (dataAccess.Remove(productNo))
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
