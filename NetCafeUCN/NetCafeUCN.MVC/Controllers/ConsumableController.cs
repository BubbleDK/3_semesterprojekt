using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Services;

namespace NetCafeUCN.MVC.Controllers
{
    public class ConsumableController : Controller
    {
        INetCafeDataAccessService<ConsumableDto> consumableService = new ConsumableService("https://localhost:7197/api/Consumable");
        // GET: ConsumableController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConsumableController/Details/5
        public ActionResult Details(string productNumber)
        {
            return View(consumableService.Get(productNumber));
        }

        // GET: ConsumableController/Create
        public ActionResult Create(string productNumber)
        {
            return View(consumableService.Get(productNumber));
        }

        // POST: ConsumableController/Create
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

        // GET: ConsumableController/Edit/5
        public ActionResult Edit(string productNumber)
        {
            return View(consumableService.Get(productNumber));
        }

        // POST: ConsumableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Delete(string productNumber)
        {
            return View(consumableService.Get(productNumber));
        }

        // POST: ConsumableController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
