using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Services;

namespace NetCafeUCN.MVC.Controllers
{
    [Authorize]
    public class GamingStationController : Controller
    {
        INetCafeDataAccessService<GamingStationDto> gamingStationService = new GamingstationService("https://localhost:7197/api/GamingStation");
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
            return View(gamingStationService.Get(productNumber));
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
            return View(gamingStationService.Get(productNumber));
        }

        // POST: GamingStationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(GamingStationDto editedGamingstation)
        {
            try
            {
                var gamingstation = gamingStationService.Get(editedGamingstation.ProductNumber);
                gamingstation.SeatNumber = editedGamingstation.SeatNumber;
                gamingstation.Description = editedGamingstation.Description;
                gamingstation.Name = editedGamingstation.Name;
                gamingStationService.Update(gamingstation);
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
            GamingStationDto gamingStation = gamingStationService.Get(productNumber);
            return View(gamingStation);
        }

        // POST: GamingStationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string ProductNumber)
        {
            try
            {
                gamingStationService.Remove(productNumber);
                return RedirectToAction(nameof(Index), "Product");
            }
            catch
            {
                return View();
            }
        }
    }
}
