using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCafeUCN.API.Controllers
{
    /// <summary>
    ///  API Controller for User, som implementere ControllerBase
    /// </summary>
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly INetCafeUCNUserDAO userDAO;
        /// <summary>
        ///  UserController constructor
        /// </summary>
        /// <param name="userDAO">Model som skal sættes for controlleren</param>
        public UserController(INetCafeUCNUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }

        /// <summary>
        ///  Henter alle users
        /// </summary>
        /// <returns>Returnere en collection af users</returns>
        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            return userDAO.GetAll().ToDtos();
        }

        /// <summary>
        ///  Henter en bestemt user
        /// </summary>
        /// <param name="user">Et objekt af en user</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPost]
        public ActionResult<UserDTO?> Get([FromBody] UserDTO user)
        {
            return Ok(userDAO.GetUserByLogin(user.Email, user.PasswordHash).ToDto());
        }

        /// <summary>
        ///  Henter et bestemt hash ved brug af email
        /// </summary>
        /// <param name="user">Et objekt af en user</param>
        /// <returns>Returnere status kode 200 for OK</returns>
        [HttpPost]
        [Route("GetHashByEmail")]
        public ActionResult<UserLoginDTO?> GetHashByEmail([FromBody] UserLoginDTO user)
        {
            return Ok(userDAO.GetHashByEmail(user.Email));
        }
    }
}
