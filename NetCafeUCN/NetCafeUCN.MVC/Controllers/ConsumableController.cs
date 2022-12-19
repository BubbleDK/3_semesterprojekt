using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Services;

namespace NetCafeUCN.MVC.Controllers
{
    /// <summary>
    ///  ConsumableController klasse, nedarver fra controller klassen
    /// </summary>
    [Authorize]
    public class ConsumableController : Controller
    {
        readonly INetCafeDataAccessService<ConsumableDto> _consumableService;

        /// <summary>
        /// ConsumableController constructor
        /// </summary>
        /// <param name="consumableService">Sæt den consumable service som skal bruges i klassen</param>
        public ConsumableController(INetCafeDataAccessService<ConsumableDto> consumableService)
        {
            _consumableService = consumableService;
        }


        // GET: ConsumableController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get metode til details view.
        /// </summary>
        /// <param name="productNumber">string af produkt nummeret</param>
        /// <returns>Returnere et View med det bestemte produkt</returns>
        // GET: ConsumableController/Details/5
        [AllowAnonymous]
        public ActionResult Details(string productNumber)
        {
            return View(_consumableService.Get(productNumber));
        }

        /// <summary>
        /// Get metode til create view.
        /// </summary>
        /// <param name="productNumber">string af produkt nummeret</param>
        /// <returns>Returnere et View med det bestemte produkt</returns>
        // GET: ConsumableController/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(string productNumber)
        {
            return View(_consumableService.Get(productNumber));
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        // POST: ConsumableController/Create
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
        /// Get metode til edit view.
        /// </summary>
        /// <param name="productNumber">string af produkt nummeret</param>
        /// <returns>Returnere et View med det bestemte produkt</returns>
        // GET: ConsumableController/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string productNumber)
        {
            return View(_consumableService.Get(productNumber));
        }

        /// <summary>
        /// Post metode til at redigere et produkt
        /// </summary>
        /// <param name="editedConsumable">Objekt af ConsumableDto</param>
        /// <returns>Returnere et View med produkter</returns>
        // POST: ConsumableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(ConsumableDto editedConsumable)
        {
            try
            {
                var consumable = _consumableService.Get(editedConsumable.ProductNumber);
                consumable.Description = editedConsumable.Description;
                consumable.Name = editedConsumable.Name;
                _consumableService.Update(consumable);
                return RedirectToAction(nameof(Index), "Product");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Get metode til delete view.
        /// </summary>
        /// <param name="productNumber">string af produkt nummeret</param>
        /// <returns>Returnere et View med det bestemte produkt</returns>
        // GET: ConsumableController/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string productNumber)
        {
            return View(_consumableService.Get(productNumber));
        }

        /// <summary>
        /// Post til at delete et consumable
        /// </summary>
        /// <param name="consumableToDelete">Objekt af ConsumableDto</param>
        /// <returns>Returnere et View</returns>
        // POST: ConsumableController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(ConsumableDto consumableToDelete)
        {
            try
            {
                _consumableService.Remove(consumableToDelete.ProductNumber);
                return RedirectToAction(nameof(Index), "Product");
            }
            catch
            {
                return View();
            }
        }
    }
}
