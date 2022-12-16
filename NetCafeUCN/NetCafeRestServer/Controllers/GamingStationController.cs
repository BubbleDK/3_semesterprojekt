using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    [Route("gamingstations")]
    [ApiController]
    public class GamingStationController : ControllerBase
    {
        private readonly INetCafeDAO<GamingStation> dataAccess;
        

        public GamingStationController(INetCafeDAO<GamingStation> dataAccess)
        {
            this.dataAccess = dataAccess;
           
        }

        // GET: api/<GamingStationController>
        [HttpGet]
        public ActionResult<IEnumerable<GamingStationDTO>> GetAll()
        {
            return Ok(dataAccess.GetAll().GSToDtos());
        }

        // GET api/<GamingStationController>/74747
        [HttpGet]
        [Route("{productNo}")]
        public ActionResult<GamingStationDTO> Get(string productNo)
        {
            return Ok(dataAccess.Get(productNo).GSToDto());
        }

        // POST api/<GamingStationController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody]GamingStationDTO p)
        {
            return Ok(dataAccess.Add(p.GSFromDto()));
        }

        // PUT api/<GamingStationController>/
        [HttpPut]
        public ActionResult<GamingStation> Update(GamingStationDTO product)
        {
            return Ok(dataAccess.Update(product.GSFromDto()));
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
