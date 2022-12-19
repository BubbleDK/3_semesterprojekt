using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    /// <summary>
    ///  API Controller for Consumable, som implementere ControllerBase
    /// </summary>
    [Route("consumables")]
    [ApiController]
    public class ConsumableController : ControllerBase
    {
        private readonly INetCafeDAO<Consumable> dataAccess;

        /// <summary>
        ///  ConsumableController constructor
        /// </summary>
        /// <param name="dataAccess">Model som skal sættes for controlleren</param>
        public ConsumableController(INetCafeDAO<Consumable> dataAccess)
        {
            this.dataAccess = dataAccess;

        }

        // GET: api/<ConsumableController>
        /// <summary>
        ///  Henter alle consumables
        /// </summary>
        /// <returns>Returnere en collection af consumables</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ConsumableDTO>> GetAll()
        {
            return Ok(dataAccess.GetAll().CSToDtos());
        }

        // GET api/<ConsumableController>/74747
        /// <summary>
        ///  Henter en bestemt consumable
        /// </summary>
        /// <param name="productNo">produkt nummer på den bestemte consumable</param>
        /// <returns>Returnere den bestemte consumable eller 404 status kode hvis den ikke blev fundet</returns>
        [HttpGet]
        [Route("{productNo}")]
        public ActionResult<ConsumableDTO> Get(string productNo)
        {
            var product = dataAccess.Get(productNo).CSToDto();
            if (product == null) { return NotFound(); }
            return Ok(product);
        }

        // POST api/<ConsumableController>
        /// <summary>
        ///  Opretter et ny consumable
        /// </summary>
        /// <param name="p">Objekt af en consumable</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] ConsumableDTO p)
        {
            return Ok(dataAccess.Add(p.CSFromDto()));
        }

        // PUT api/<ConsumableController>/
        /// <summary>
        ///  Opdatere en consumable
        /// </summary>
        /// <param name="p">Objekt af en consumable</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPut]
        public ActionResult<bool> Update(ConsumableDTO p)
        {
            return Ok(dataAccess.Update(p.CSFromDto()));
        }

        // DELETE api/<ConsumableController>/40559810
        /// <summary>
        ///  Sletter en booking
        /// </summary>
        /// <param name="productNo">Produkt nummer på den consumable der skal slettes</param>
        /// <returns>Returnere status kode 200 hvis den blev fjernet, eller 404 status kode hvis den ikke blev fundet</returns>
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
