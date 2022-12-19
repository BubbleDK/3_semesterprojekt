using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Models.DTO;
using NetCafeUCN.MVC.Services;

namespace NetCafeUCN.MVC.Controllers
{
    /// <summary>
    /// ProductController klasse, nedarver fra Controller
    /// </summary>
    [Authorize]
    public class ProductController : Controller
    {
        readonly INetCafeDataAccessService<GamingStationDto> _gamingStationService;
        readonly INetCafeDataAccessService<ConsumableDto> _consumableService;
        static GamingStationConsumableViewModel viewModel = new GamingStationConsumableViewModel();

        /// <summary>
        /// ProductController constructor
        /// </summary>
        /// <param name="gamingStationService">Sæt den gamingstation service som skal bruges i klassen</param>
        /// <param name="consumableService">Sæt den consumable service som skal bruges i klassen</param>
        public ProductController(INetCafeDataAccessService<GamingStationDto> gamingStationService, INetCafeDataAccessService<ConsumableDto> consumableService)
        {
            _gamingStationService = gamingStationService;
            _consumableService = consumableService;
        }

        /// <summary>
        /// Get metode til index view
        /// </summary>
        /// <returns>Et view med alle gaming station og consumables</returns>
        // GET: ProductController
        [AllowAnonymous]
        public ActionResult Index()
        {
            viewModel.gamingStations = _gamingStationService.GetAll();
            viewModel.consumables = _consumableService.GetAll();
            return View(viewModel);
        }

        /// <summary>
        /// Get metode til details view
        /// </summary>
        /// <returns></returns>
        // GET: ProductController/Details/5
        [AllowAnonymous]
        public ActionResult Details()
        {
            return View();
        }

        /// <summary>
        /// Get metode til Create view
        /// </summary>
        /// <returns></returns>
        // GET: ProductController/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Get metode til Edit view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Get metode til delete view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: ProductController/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
