using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    [Route("consumables")]
    [ApiController]
    public class ConsumableController : ControllerBase
    {
        private readonly INetCafeDAO<Consumable> dataAccess;


        public ConsumableController(INetCafeDAO<Consumable> dataAccess)
        {
            this.dataAccess = dataAccess;

        }

        // GET: api/<ConsumableController>
        [HttpGet]
        public ActionResult<IEnumerable<ConsumableDTO>> GetAll()
        {
            return Ok(dataAccess.GetAll().CSToDtos());
        }

        // GET api/<ConsumableController>/74747
        [HttpGet]
        [Route("{productNo}")]
        public ActionResult<ConsumableDTO> Get(string productNo)
        {
            var product = dataAccess.Get(productNo).CSToDto();
            if (product == null) { return NotFound(); }
            return Ok(product);
        }

        // POST api/<ConsumableController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] ConsumableDTO p)
        {
            return Ok(dataAccess.Add(p.CSFromDto()));
        }

        // PUT api/<ConsumableController>/
        [HttpPut]
        public ActionResult<bool> Update(ConsumableDTO p)
        {
            return Ok(dataAccess.Update(p.CSFromDto()));
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
