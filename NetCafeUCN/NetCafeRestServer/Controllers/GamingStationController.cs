using DataAccessLayer.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingStationController : ControllerBase
    {
        private INetCafeDataAccess<GamingStation> dataAccess;

        public GamingStationController(INetCafeDataAccess<GamingStation> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<GamingStation>> GetAll()
        {
            return Ok(dataAccess.GetAll());
        }

        
    }
}
