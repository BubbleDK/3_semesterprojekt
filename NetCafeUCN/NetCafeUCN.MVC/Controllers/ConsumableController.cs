using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Services;

namespace NetCafeUCN.MVC.Controllers
{
    [Authorize]
    public class ConsumableController : Controller
    {
        INetCafeDataAccessService<ConsumableDto> _consumableService;

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

        // GET: ConsumableController/Details/5
        [AllowAnonymous]
        public ActionResult Details(string productNumber)
        {
            return View(consumableService.Get(productNumber));
        }

        // GET: ConsumableController/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(string productNumber)
        {
            return View(consumableService.Get(productNumber));
        }

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

        // GET: ConsumableController/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string productNumber)
        {
            return View(consumableService.Get(productNumber));
        }

        // POST: ConsumableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(ConsumableDto editedConsumable)
        {
            try
            {
                var consumable = consumableService.Get(editedConsumable.ProductNumber);
                consumable.Description = editedConsumable.Description;
                consumable.Name = editedConsumable.Name;
                consumableService.Update(consumable);
                return RedirectToAction(nameof(Index), "Product");
            }
            catch
            {
                return View();
            }
        }

        // GET: ConsumableController/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string productNumber)
        {
            return View(consumableService.Get(productNumber));
        }

        // POST: ConsumableController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(ConsumableDto consumableToDelete)
        {
            try
            {
                consumableService.Remove(consumableToDelete.ProductNumber);
                return RedirectToAction(nameof(Index), "Product");
            }
            catch
            {
                return View();
            }
        }
    }
}
