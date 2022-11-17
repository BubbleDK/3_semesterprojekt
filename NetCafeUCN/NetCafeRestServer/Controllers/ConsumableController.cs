using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumableController : ControllerBase
    {
        private INetCafeDAO<Consumable> dataAccess;


        public ConsumableController(INetCafeDAO<Consumable> dataAccess)
        {
            this.dataAccess = dataAccess;

        }

        // GET: api/<ConsumableController>
        [HttpGet]
        public ActionResult<IEnumerable<Consumable>> GetAll()
        {
            return Ok(dataAccess.GetAll());
        }

        // GET api/<ConsumableController>/74747
        [HttpGet]
        [Route("{productNo}")]
        public ActionResult<Consumable> Get(string productNo)
        {
            var product = dataAccess.Get(productNo);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }

        // POST api/<ConsumableController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Consumable p)
        {
            return Ok(dataAccess.Add(p));
        }

        // PUT api/<ConsumableController>/
        [HttpPut]
        public ActionResult<bool> Update(Consumable product)
        {
            return Ok(dataAccess.Update(product));
        }

        // DELETE api/<ConsumableController>/40559810
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
