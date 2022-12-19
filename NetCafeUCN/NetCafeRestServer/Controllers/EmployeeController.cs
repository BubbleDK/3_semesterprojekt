using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    /// <summary>
    ///  API Controller for Employee, som implementere ControllerBase
    /// </summary>
    [Route("employees")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly INetCafeDAO<Employee> dataAccess;
        /// <summary>
        ///  EmployeeController constructor
        /// </summary>
        /// <param name="dataAccess">Model som skal sættes for controlleren</param>
        public EmployeeController(INetCafeDAO<Employee> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        /// <summary>
        ///  Henter alle employees
        /// </summary>
        /// <returns>Returnere en collection af Employees</returns>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> GetAll()
        {
            return Ok(dataAccess.GetAll().EmployeeToDtos());
        }

        // GET api/<Employee>/74747
        /// <summary>
        ///  Henter en bestemt employee
        /// </summary>
        /// <param name="phoneNo">telefon nummer på den bestemte employee</param>
        /// <returns>Returnere den bestemte employee eller 404 status kode hvis den ikke blev fundet</returns>
        [HttpGet]
        [Route("{phoneNo}")]
        public ActionResult<EmployeeDTO> Get(string phoneNo)
        {
            var product = dataAccess.Get(phoneNo).EmployeeToDto();
            if (product == null) { return NotFound(); }

            return Ok(product);
        }

        // POST api/<EmployeeController>
        /// <summary>
        ///  Opretter en ny employee
        /// </summary>
        /// <param name="p">Objekt af en employee</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] EmployeeDTO p)
        {
            return Ok(dataAccess.Add(p.EmployeeFromDto()));
        }

        // PUT api/<EmployeeController>/
        /// <summary>
        ///  Opdatere en employee
        /// </summary>
        /// <param name="p">Objekt af en employee</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPut]
        public ActionResult<bool> Update(EmployeeDTO p)
        {
            return Ok(dataAccess.Update(p.EmployeeFromDto()));
        }

        // DELETE api/<EmployeeController>/40559810
        /// <summary>
        ///  Sletter en employee
        /// </summary>
        /// <param name="phoneNo">Telefon nummer på den employee der skal slettes</param>
        /// <returns>Returnere status kode 200 hvis den blev fjernet, eller 404 status kode hvis den ikke blev fundet</returns>
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
