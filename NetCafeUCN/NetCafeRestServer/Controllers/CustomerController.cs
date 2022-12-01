using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private INetCafeDAO<Customer> dataAccess;


        public CustomerController(INetCafeDAO<Customer> dataAccess)
        {
            this.dataAccess = dataAccess;

        }

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDTO>> GetAll()
        {
            return Ok(dataAccess.GetAll().CustomerToDtos());
        }

        // GET api/<ProductController>/74747
        [HttpGet]
        [Route("{phoneNo}")]
        public ActionResult<CustomerDTO> Get(string phoneNo)
        {
            var product = dataAccess.Get(phoneNo).CustomerToDto();
            if (product == null) { return NotFound(); }

            return Ok(product);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] CustomerDTO p)
        {
            return Ok(dataAccess.Add(p.CustomerFromDto()));
        }

        // PUT api/<ProductController>/
        [HttpPut]
        public ActionResult<bool> Update(CustomerDTO p)
        {
            return Ok(dataAccess.Update(p.CustomerFromDto()));
        }

        // DELETE api/<CustomerController>/40559810
        [HttpDelete("{phoneNo}")]
        public ActionResult<bool> Delete(string phoneNo)
        {
            if (dataAccess.Remove(phoneNo))
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


