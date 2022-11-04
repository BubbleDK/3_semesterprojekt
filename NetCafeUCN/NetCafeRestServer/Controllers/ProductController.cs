using DataAccessLayer.DAO;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private INetCafeDataAccess<Product> dataAccess;

        public ProductController(INetCafeDataAccess<Product> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(dataAccess.GetAll());
        }

        // GET api/<ProductController>/74747
        [HttpGet]
        [Route("{productNo}")]
        public ActionResult<Product> Get(string productNo)
        {
            var person = dataAccess.Get(productNo);
            if (person == null) { return NotFound(); }
            return Ok(person);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<int> Add(Product product)
        {
            return Ok(dataAccess.Add(product));
        }

        // PUT api/<ProductController>/
        [HttpPut]
        public ActionResult<bool> Update(Product product)
        {
            return Ok(dataAccess.Update(product));
        }

        // DELETE api/<ProductController>/40559810
        [HttpDelete("{productNo}")]
        public ActionResult<bool> Delete(string productNo)
        {
            if (dataAccess.Remove(Int32.Parse(productNo)))
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
