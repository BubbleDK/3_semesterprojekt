using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Services;

namespace NetCafeUCN.MVC.Controllers
{
    [Authorize]
    public class GamingStationController : Controller
    {
        readonly INetCafeDataAccessService<GamingStationDto> _gamingStationService;
        public GamingStationController(INetCafeDataAccessService<GamingStationDto> gamingStationService)
        {
            _gamingStationService = gamingStationService;
        }

        // GET: GamingStationController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        // GET: GamingStationController/Details/5
        [AllowAnonymous]
        public ActionResult Details(string productNumber)
        {
            return View(_gamingStationService.Get(productNumber));
        }


        // GET: GamingStationController/Create
        [Authorize(Roles ="Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GamingStationController/Create
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

        // GET: GamingStationController/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string productNumber)
        {
            return View(_gamingStationService.Get(productNumber));
        }

        // POST: GamingStationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(GamingStationDto editedGamingstation)
        {
            try
            {
                var gamingstation = _gamingStationService.Get(editedGamingstation.ProductNumber);
                gamingstation.SeatNumber = editedGamingstation.SeatNumber;
                gamingstation.Description = editedGamingstation.Description;
                gamingstation.Name = editedGamingstation.Name;
                _gamingStationService.Update(gamingstation);
                return RedirectToAction(nameof(Index), "Product");
            }
            catch
            {
                return View();
            }
        }

        // GET: GamingStationController/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string? productNumber)
        {
            GamingStationDto gamingStation = _gamingStationService.Get(productNumber);
            return View(gamingStation);
        }

        // POST: GamingStationController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(string productNumber)
        {
            try
            {
                _gamingStationService.Remove(productNumber);
                return RedirectToAction(nameof(Index), "Product");
            }
            catch
            {
                return View();
            }
        }
    }
}
