using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Services;

namespace NetCafeUCN.MVC.Controllers
{
    /// <summary>
    /// GamingStationController klasse, som nedarver fra Controller
    /// </summary>
    [Authorize]
    public class GamingStationController : Controller
    {
        readonly INetCafeDataAccessService<GamingStationDto> _gamingStationService;
        /// <summary>
        /// GamingStationController constructor
        /// </summary>
        /// <param name="gamingStationService">Den ønskede service man ønsker at sætte for klassen</param>
        public GamingStationController(INetCafeDataAccessService<GamingStationDto> gamingStationService)
        {
            _gamingStationService = gamingStationService;
        }

        /// <summary>
        /// Get metode til index view
        /// </summary>
        /// <returns></returns>
        // GET: GamingStationController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get metode til at vise Details view
        /// </summary>
        /// <param name="productNumber">string af produkt nummeret</param>
        /// <returns>Et view med det bestemte produkt</returns>
        // GET: GamingStationController/Details/5
        [AllowAnonymous]
        public ActionResult Details(string productNumber)
        {
            return View(_gamingStationService.Get(productNumber));
        }

        /// <summary>
        /// Get metode til Create View
        /// </summary>
        /// <returns></returns>
        // GET: GamingStationController/Create
        [Authorize(Roles ="Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get metode til Edit view
        /// </summary>
        /// <param name="productNumber">string af produkt nummeret</param>
        /// <returns>Et view med det bestemte produkt</returns>
        // GET: GamingStationController/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string productNumber)
        {
            return View(_gamingStationService.Get(productNumber));
        }

        /// <summary>
        /// Post metode til at ændre en bestemt gaming station
        /// </summary>
        /// <param name="editedGamingstation">Objekt af typen GamingStationDto</param>
        /// <returns>Et view</returns>
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
        /// <summary>
        /// Get metode til at delete view
        /// </summary>
        /// <param name="productNumber">string af produkt nummeret</param>
        /// <returns>Et view af det bestemte produkt</returns>
        // GET: GamingStationController/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string? productNumber)
        {
            GamingStationDto gamingStation = _gamingStationService.Get(productNumber);
            return View(gamingStation);
        }

        /// <summary>
        /// Post metode til at bekræfte at man ønsker at slette produktet
        /// </summary>
        /// <param name="productNumber">string af produkt nummeret</param>
        /// <returns>Et view af alle produkter</returns>
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
