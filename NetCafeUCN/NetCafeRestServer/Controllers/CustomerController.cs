using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    /// <summary>
    ///  API Controller for Customer, som implementere ControllerBase
    /// </summary>
    [Route("customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly INetCafeDAO<Customer> dataAccess;

        /// <summary>
        ///  CustomerController constructor
        /// </summary>
        /// <param name="dataAccess">Model som skal sættes for controlleren</param>
        public CustomerController(INetCafeDAO<Customer> dataAccess)
        {
            this.dataAccess = dataAccess;

        }

        // GET: api/<CustomerController>
        /// <summary>
        ///  Henter alle customers
        /// </summary>
        /// <returns>Returnere en collection af Customer</returns>
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDTO>> GetAll()
        {
            return Ok(dataAccess.GetAll().CustomerToDtos());
        }

        // GET api/<CustomerController>/74747
        /// <summary>
        ///  Henter en bestemt customer
        /// </summary>
        /// <param name="phoneNo">telefon nummer på den bestemte customer</param>
        /// <returns>Returnere den bestemte customer eller 404 status kode hvis den ikke blev fundet</returns>
        [HttpGet]
        [Route("{phoneNo}")]
        public ActionResult<CustomerDTO> Get(string phoneNo)
        {
            var customer = dataAccess.Get(phoneNo).CustomerToDto();
            if (customer == null) { return NotFound(); }

            return Ok(customer);
        }

        // POST api/<CustomerController>
        /// <summary>
        ///  Opretter en ny customer
        /// </summary>
        /// <param name="p">Objekt af en Customer</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] CustomerDTO p)
        {
            var customer = dataAccess.Add(p.CustomerFromDto());
            return Ok(customer);
        }

        // PUT api/<ProductController>/
        /// <summary>
        ///  Opdatere en customer
        /// </summary>
        /// <param name="p">Objekt af en customer</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPut]
        public ActionResult<bool> Update(CustomerDTO p)
        {
            return Ok(dataAccess.Update(p.CustomerFromDto()));
        }

        // DELETE api/<CustomerController>/40559810
        /// <summary>
        ///  Sletter en customer
        /// </summary>
        /// <param name="phoneNo">Telefon nummer på den customer der skal slettes</param>
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


