using Microsoft.AspNetCore.Mvc;

namespace NetCafeUCN.API.Controllers
{
    public class GenericProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
