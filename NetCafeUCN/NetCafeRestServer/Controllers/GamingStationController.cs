using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    /// <summary>
    ///  API Controller for Gamingstations, som implementere ControllerBase
    /// </summary>
    [Route("gamingstations")]
    [ApiController]
    public class GamingStationController : ControllerBase
    {
        private readonly INetCafeDAO<GamingStation> dataAccess;

        /// <summary>
        ///  GamingStationController constructor
        /// </summary>
        /// <param name="dataAccess">Model som skal sættes for controlleren</param>
        public GamingStationController(INetCafeDAO<GamingStation> dataAccess)
        {
            this.dataAccess = dataAccess;
           
        }

        // GET: api/<GamingStationController>
        /// <summary>
        ///  Henter alle GamingStations
        /// </summary>
        /// <returns>Returnere en collection af GamingStation</returns>
        [HttpGet]
        public ActionResult<IEnumerable<GamingStationDTO>> GetAll()
        {
            return Ok(dataAccess.GetAll().GSToDtos());
        }

        // GET api/<GamingStationController>/74747
        /// <summary>
        ///  Henter en bestemt gamingstation
        /// </summary>
        /// <param name="productNo">produkt nummer på den bestemte gamingstation</param>
        /// <returns>Returnere den bestemte gamingstation eller 404 status kode hvis den ikke blev fundet</returns>
        [HttpGet]
        [Route("{productNo}")]
        public ActionResult<GamingStationDTO> Get(string productNo)
        {
            return Ok(dataAccess.Get(productNo).GSToDto());
        }

        // POST api/<GamingStationController>
        /// <summary>
        ///  Opretter en ny gamingstation
        /// </summary>
        /// <param name="p">Objekt af en gamingstation</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPost]
        public ActionResult<bool> Add([FromBody]GamingStationDTO p)
        {
            return Ok(dataAccess.Add(p.GSFromDto()));
        }

        // PUT api/<GamingStationController>/
        /// <summary>
        ///  Opdatere en gamingstation
        /// </summary>
        /// <param name="product">Objekt af en gamingstation</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPut]
        public ActionResult<GamingStation> Update(GamingStationDTO product)
        {
            return Ok(dataAccess.Update(product.GSFromDto()));
        }

        // DELETE api/<GamingStationController>/40559810
        /// <summary>
        ///  Sletter en gamingstation
        /// </summary>
        /// <param name="productNo">Produkt nummer på den gamingstation der skal slettes</param>
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
