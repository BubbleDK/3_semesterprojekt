using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Services;

namespace NetCafeUCN.MVC.Controllers
{
    public class GamingStationController : Controller
    {
        INetCafeDataAccessService<GamingStationDto> gamingStationService = new GamingstationService("https://localhost:7197/api/GamingStation");
        // GET: GamingStationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GamingStationController/Details/5
        public ActionResult Details(string productNumber)
        {
            return View(gamingStationService.Get(productNumber));
        }

        // GET: GamingStationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GamingStationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Edit(string productNumber)
        {
            return View(gamingStationService.Get(productNumber));
        }

        // POST: GamingStationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GamingStationDto editedGamingstation)
        {
            try
            {
                var gamingstation = gamingStationService.Get(editedGamingstation.ProductNumber);
                gamingstation.SeatNumber = editedGamingstation.SeatNumber;
                gamingstation.Description = editedGamingstation.Description;
                gamingStationService.Update(gamingstation);
                return RedirectToAction(nameof(Index), "Product");
            }
            catch
            {
                return View();
            }
        }

        // GET: GamingStationController/Delete/5
        public ActionResult Delete(string productNumber)
        {
            return View(gamingStationService.Get(productNumber));
        }

        // POST: GamingStationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GamingStationDto gamingstationToDelete)
        {
            try
            {
                gamingStationService.Remove(gamingstationToDelete.ProductNumber);
                return RedirectToAction(nameof(Index), "Product");
            }
            catch
            {
                return View();
            }
        }
    }
}
