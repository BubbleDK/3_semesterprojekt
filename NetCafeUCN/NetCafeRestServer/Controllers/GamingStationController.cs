using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingStationController : ControllerBase
    {
        private INetCafeDAO<GamingStation> dataAccess;
        

        public GamingStationController(INetCafeDAO<GamingStation> dataAccess)
        {
            this.dataAccess = dataAccess;
           
        }

        // GET: api/<GamingStationController>
        [HttpGet]
        public ActionResult<IEnumerable<GamingStation>> GetAll()
        {
            return Ok(dataAccess.GetAll());
        }

        // GET api/<GamingStationController>/74747
        [HttpGet]
        [Route("{productNo}")]
        public ActionResult<GamingStation> Get(string productNo)
        {
            

            return Ok(dataAccess.Get(productNo));
        }

        // POST api/<GamingStationController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody]GamingStation p)
        {

            return Ok(dataAccess.Add(p));
        }

        // PUT api/<GamingStationController>/
        [HttpPut]
        public ActionResult<bool> Update(GamingStation product)
        {
            return Ok(dataAccess.Update(product));
        }

        // DELETE api/<GamingStationController>/40559810
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
