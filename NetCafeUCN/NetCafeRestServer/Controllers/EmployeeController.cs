using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private INetCafeDAO<Employee> dataAccess;
        public EmployeeController(INetCafeDAO<Employee> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            return Ok(dataAccess.GetAll());
        }

        // GET api/<Employee>/74747
        [HttpGet]
        [Route("{phoneNo}")]
        public ActionResult<Employee> Get(string phoneNo)
        {
            var product = dataAccess.Get(phoneNo);
            if (product == null) { return NotFound(); }

            return Ok(product);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Employee p)
        {
            return Ok(dataAccess.Add(p));
        }

        // PUT api/<EmployeeController>/
        [HttpPut]
        public ActionResult<bool> Update(Employee person)
        {
            return Ok(dataAccess.Update(person));
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
