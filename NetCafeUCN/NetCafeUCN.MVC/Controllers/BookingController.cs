﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Models.DTO;
using NetCafeUCN.MVC.Services;
using System.Reflection;
using System.Security.Claims;

namespace NetCafeUCN.MVC.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        INetCafeDataAccessService<GamingStationDto> gamingStationService = new GamingstationService("https://localhost:7197/api/GamingStation");
        INetCafeDataAccessService<BookingDto> bookingService = new BookingService("https://localhost:7197/api/Booking");
        BookingLineService bookingLineService = new BookingLineService("https://localhost:7197/api/BookingLine");
        // GET: BookingController
        public ActionResult Index()
        {
            List<BookingDto> bookings = bookingService.GetAll().ToList();

            return View(bookings);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(string bookingNo)
        {
            BookingDto booking = bookingService.Get(bookingNo);
            booking.BookingLines = bookingLineService.GetAll(bookingNo).ToList();
            return View(booking);
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            BookingGamingStationViewModel viewModel = new BookingGamingStationViewModel();
            viewModel.GamingStations = (List<GamingStationDto>)gamingStationService.GetAll();

            return View(viewModel);
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] BookingGamingStationViewModel bookingModel)
        {
            try
            {
                BookingDto booking = new BookingDto();
                booking.PhoneNo = bookingModel.PhoneNo;
                string dateString = "" + bookingModel.StartDate + " " + bookingModel.StartTime;
                DateTime start = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
                booking.StartTime = start;
                booking.EndTime = start.AddHours(double.Parse(bookingModel.EndTime, System.Globalization.CultureInfo.InvariantCulture));
                List<GamingStationDto> allGamingStations = gamingStationService.GetAll().ToList();
                if (bookingModel.GamingStations != null)
                {
                    for (int i = 0; i < bookingModel.GamingStations.Count(); i++)
                    {
                        if (bookingModel.GamingStations[i].isChecked)
                        {
                            booking.BookingLines.Add(new BookingLineDto()
                            {
                                Quantity = 1,
                                Stationid = allGamingStations[i].ProductID,
                                Consumableid = 0,
                            });
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Null");
                }
                bookingService.Add(booking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // POST: BookingController/Edit/5
        [HttpPost]
        [Authorize]
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

        // GET: BookingController/Delete/5
        public ActionResult Delete(string? bookingNo)
        {
            BookingDto bookingToDelete = bookingService.Get(bookingNo);
            return View(bookingToDelete);
        }

        // POST: BookingController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string bookingNo, string phoneNo)
        {
            try
            {
                if(phoneNo == User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.MobilePhone)?.Value)
                {
                    bookingService.Remove(bookingNo);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //[HttpPost]
        //public JsonResult AddBooking([FromForm] GamingStationDto whatever)
        //{
        //    Console.WriteLine("ADD BOOKING TRIGGERED");
        //    foreach (var item in stations)
        //    {
        //        Console.WriteLine(item.SeatNumber);
        //    }

        //    return null;
        //}
    }
}
