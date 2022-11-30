﻿using Microsoft.AspNetCore.Authorization;
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
        INetCafeDataAccessService<GamingStationDto> gamingStationService = new GamingstationService("https://localhost:7197/api/GamingStation");
        INetCafeDataAccessService<ConsumableDto> consumableService = new ConsumableService("https://localhost:7197/api/Consumable");
        static GamingStationConsumableViewModel viewModel = new GamingStationConsumableViewModel();
        // GET: ProductController
        [AllowAnonymous]
        public ActionResult Index()
        {
            viewModel.gamingStations = gamingStationService.GetAll();
            viewModel.consumables = consumableService.GetAll();
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
