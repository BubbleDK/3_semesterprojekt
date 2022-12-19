using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using System.Diagnostics;

namespace NetCafeUCN.MVC.Controllers
{
    /// <summary>
    /// HomeController klasse, som nedarver fra Controller.
    /// </summary>
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// HomeController constructor
        /// </summary>
        /// <param name="logger">Kategorinavn</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get metode til index view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get metode til Privacy view
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Get metode til Error view
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}