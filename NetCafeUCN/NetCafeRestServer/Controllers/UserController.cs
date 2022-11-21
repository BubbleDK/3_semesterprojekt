using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserDAO userDAO;
        public UserController(UserDAO userDAO)
        {
            this.userDAO = userDAO;
        }

        // GET api/<UserController>/5
        [HttpPost]
        public ActionResult<User?> Get(string email, string password)
        {
            return Ok(userDAO.GetUserByLogin(email, password));
        }
       
    }
}
