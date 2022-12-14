using Microsoft.AspNetCore.Authorization;
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

        INetCafeDataAccessService<GamingStationDto> _gamingStationService;
        INetCafeDataAccessService<BookingDto> _bookingService;
        BookingLineService _bookingLineService;
        // GET: BookingController
        public BookingController(INetCafeDataAccessService<GamingStationDto> gamingStationService, INetCafeDataAccessService<BookingDto> bookingService, BookingLineService bookingLineService)
        {
            _gamingStationService = gamingStationService;
            _bookingService = bookingService;
            _bookingLineService = bookingLineService;
        }
        public ActionResult Index()
        {
            List<BookingDto> bookings = _bookingService.GetAll().ToList();

            return View(bookings);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(string bookingNo)
        {
            BookingDto booking = _bookingService.Get(bookingNo);
            booking.BookingLines = _bookingLineService.GetAll(bookingNo).ToList();
            return View(booking);
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            BookingGamingStationViewModel viewModel = new BookingGamingStationViewModel();
            viewModel.GamingStations = (List<GamingStationDto>)_gamingStationService.GetAll();

            return View(viewModel);
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] BookingGamingStationViewModel bookingModel)
        {
            try
            {
                bool isAnyItemTrue = false;
                foreach (var item in bookingModel.GamingStations)
                {
                    if (item.isChecked)
                    {
                        isAnyItemTrue = true;
                        break;
                    }
                }

                if (!isAnyItemTrue)
                {
                    bookingModel.GamingStations = (List<GamingStationDto>)_gamingStationService.GetAll();
                    ViewBag.Error = "Du skal vælge en maskine! :(";
                    return View(bookingModel);
                }

                BookingDto booking = new BookingDto();
                booking.PhoneNo = bookingModel.PhoneNo;
                string dateString = "" + bookingModel.StartDate + " " + bookingModel.StartTime;
                DateTime start = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
                if (!(start.AddSeconds(-1).Hour > 9 && start.AddSeconds(-1800).Hour < 24 && start.AddHours(double.Parse(bookingModel.EndTime, System.Globalization.CultureInfo.InvariantCulture)).AddSeconds(-1).Hour < 24 && start.AddHours(double.Parse(bookingModel.EndTime, System.Globalization.CultureInfo.InvariantCulture)).AddSeconds(1800).Hour > 9))
                {
                    bookingModel.GamingStations = (List<GamingStationDto>)_gamingStationService.GetAll();
                    ViewBag.Error = "Du kan kun book en tid indenfor vores åbeningstid";
                    return View(bookingModel);
                }
                booking.StartTime = start;
                booking.EndTime = start.AddHours(double.Parse(bookingModel.EndTime, System.Globalization.CultureInfo.InvariantCulture));
                List<GamingStationDto> allGamingStations = _gamingStationService.GetAll().ToList();
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
                if(_bookingService.Add(booking))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    bookingModel.GamingStations = (List<GamingStationDto>)_gamingStationService.GetAll();
                    ViewBag.Error = "Tidsrummet er optaget :(";
                    return View(bookingModel);
                }
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
            BookingDto bookingToDelete = _bookingService.Get(bookingNo);
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
                    _bookingService.Remove(bookingNo);
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
