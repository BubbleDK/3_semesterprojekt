using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.Conversion;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCafeUCN.API.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly INetCafeUCNUserDAO userDAO;
        public UserController(INetCafeUCNUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }


        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            return userDAO.GetAll().ToDtos();
        }


        [HttpPost]
        public ActionResult<UserDTO?> Get([FromBody] UserDTO user)
        {
            return Ok(userDAO.GetUserByLogin(user.Email, user.PasswordHash).ToDto());
        }

        [HttpPost]
        [Route("GetHashByEmail")]
        public ActionResult<UserLoginDto?> GetHashByEmail([FromBody] UserLoginDto user)
        {
            return Ok(userDAO.GetHashByEmail(user.Email));
        }
    }
}
