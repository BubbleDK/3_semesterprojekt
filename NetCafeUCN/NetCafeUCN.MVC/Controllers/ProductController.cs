using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Models.DTO;
using NetCafeUCN.MVC.Services;

namespace NetCafeUCN.MVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        INetCafeDataAccessService<GamingStationDto> _gamingStationService;
        INetCafeDataAccessService<ConsumableDto> _consumableService;
        static GamingStationConsumableViewModel viewModel = new GamingStationConsumableViewModel();

        public ProductController(INetCafeDataAccessService<GamingStationDto> gamingStationService, INetCafeDataAccessService<ConsumableDto> consumableService)
        {
            _gamingStationService = gamingStationService;
            _consumableService = consumableService;
        }


        // GET: ProductController
        [AllowAnonymous]
        public ActionResult Index()
        {
            viewModel.gamingStations = _gamingStationService.GetAll();
            viewModel.consumables = _consumableService.GetAll();
            return View(viewModel);
        }

        // GET: ProductController/Details/5
        [AllowAnonymous]
        public ActionResult Details(string productNumber)
        {
            return View();
        }

        // GET: ProductController/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

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
        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

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

        // GET: ProductController/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            return View();
        }

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
