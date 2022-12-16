using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    [Route("employees")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly INetCafeDAO<Employee> dataAccess;
        public EmployeeController(INetCafeDAO<Employee> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> GetAll()
        {
            return Ok(dataAccess.GetAll().EmployeeToDtos());
        }

        // GET api/<Employee>/74747
        [HttpGet]
        [Route("{phoneNo}")]
        public ActionResult<EmployeeDTO> Get(string phoneNo)
        {
            var product = dataAccess.Get(phoneNo).EmployeeToDto();
            if (product == null) { return NotFound(); }

            return Ok(product);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] EmployeeDTO p)
        {
            return Ok(dataAccess.Add(p.EmployeeFromDto()));
        }

        // PUT api/<EmployeeController>/
        [HttpPut]
        public ActionResult<bool> Update(EmployeeDTO p)
        {
            return Ok(dataAccess.Update(p.EmployeeFromDto()));
        }

        // DELETE api/<EmployeeController>/40559810
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
