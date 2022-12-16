using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{

    [Route("customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly INetCafeDAO<Customer> dataAccess;


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
            var customer = dataAccess.Get(phoneNo).CustomerToDto();
            if (customer == null) { return NotFound(); }

            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] CustomerDTO p)
        {
            var customer = dataAccess.Add(p.CustomerFromDto());
            return Ok(customer);
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


