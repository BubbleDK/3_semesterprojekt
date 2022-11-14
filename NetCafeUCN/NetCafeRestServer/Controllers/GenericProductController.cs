using DataAccessLayer.DAO;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.DTO;

namespace NetCafeUCN.API.Controllers
{
    public class GenericProductController<T> : Controller where T : Product
    {
        private INetCafeDataAccess<T> dataAccess;
        public GenericProductController(INetCafeDataAccess<T> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        // GET api/<ProductController>/74747
        [HttpGet]
        [Route("{productNo}")]
        public ActionResult<T> Get(string productNo)
        {
            return Ok();
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<bool> Add(T product)
        {

            return Ok(dataAccess.Add(product));
        }

        
}
    public class GamingStationController : GenericProductController<GamingStation>
    {
        public GamingStationController(INetCafeDataAccess<GamingStation> dataAccess) : base(dataAccess)
        {
            
        }
       


    }
    public class ConsumableController : GenericProductController<Consumable>
    {
        public ConsumableController(INetCafeDataAccess<Consumable> dataAccess) : base(dataAccess)
        {
        }
    }
}
