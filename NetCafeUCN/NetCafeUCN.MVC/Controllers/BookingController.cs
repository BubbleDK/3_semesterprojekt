using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Models.DTO;
using NetCafeUCN.MVC.Services;
using System.Security.Claims;

namespace NetCafeUCN.MVC.Controllers
{
    /// <summary>
    ///  BookingController klasse, nedarver fra controller klassen
    /// </summary>
    [AllowAnonymous]
    public class BookingController : Controller
    {
        readonly INetCafeDataAccessService<GamingStationDTO> _gamingStationService;
        readonly INetCafeDataAccessService<BookingDTO> _bookingService;
        readonly BookingLineService _bookingLineService;

        // GET: BookingController
        /// <summary>
        /// BookingController constructor, bliver constructed når man rammer BookingController
        /// </summary>
        /// <param name="gamingStationService">Sæt den gamingstation service som skal bruges i klassen</param>
        /// <param name="bookingService">Sæt den booking service som skal bruges i klassen</param>
        /// <param name="bookingLineService">Sæt den BookingLine service som skal bruges i klassen</param>
        public BookingController(INetCafeDataAccessService<GamingStationDTO> gamingStationService, INetCafeDataAccessService<BookingDTO> bookingService, BookingLineService bookingLineService)
        {
            _gamingStationService = gamingStationService;
            _bookingService = bookingService;
            _bookingLineService = bookingLineService;
        }
        /// <summary>
        /// Get metode til index view.
        /// </summary>
        /// <returns>Returnere et View med alle bookinger</returns>
        public ActionResult Index()
        {
            List<BookingDTO> bookings = _bookingService.GetAll().ToList();

            return View(bookings);
        }

        /// <summary>
        /// Get metode til details view.
        /// </summary>
        /// <param name="bookingNo">string af booking nummeret</param>
        /// <returns>Returnere et View med den bestemte booking</returns>
        // GET: BookingController/Details/5
        public ActionResult Details(string bookingNo)
        {
            BookingDTO booking = _bookingService.Get(bookingNo);
            booking.BookingLines = _bookingLineService.GetAll(bookingNo).ToList();
            return View(booking);
        }

        /// <summary>
        /// Get metode til Create view.
        /// </summary>
        /// <returns>Returnere et View hvor man kan oprette ny booking</returns>
        // GET: BookingController/Create
        public ActionResult Create()
        {
            BookingGamingStationViewModel viewModel = new BookingGamingStationViewModel();
            viewModel.GamingStations = (List<GamingStationDTO>)_gamingStationService.GetAll();

            return View(viewModel);
        }

        /// <summary>
        /// Post metode til opetterelse af ny booking.
        /// </summary>
        /// <param name="bookingModel">Henter data fra form som passer på BookingGamingStationViewModel</param>
        /// <returns>Returnere et ActionResult</returns>
        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] BookingGamingStationViewModel bookingModel)
        {
            try
            {
                bool isAnyItemTrue = false;
                if (bookingModel.GamingStations != null)
                {
                    foreach (var item in bookingModel.GamingStations)
                    {
                        if (item.isChecked)
                        {
                            isAnyItemTrue = true;
                            break;
                        }
                    }
                }
                if (!isAnyItemTrue)
                {
                    bookingModel.GamingStations = (List<GamingStationDTO>)_gamingStationService.GetAll();
                    ViewBag.Error = "Du skal vælge en maskine! :(";
                    return View(bookingModel);
                }

                BookingDTO booking = new BookingDTO();
                booking.PhoneNo = bookingModel.PhoneNo;
                string dateString = "" + bookingModel.StartDate + " " + bookingModel.StartTime;
                DateTime start = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
                if (!(start.AddHours(double.Parse(bookingModel.EndTime, System.Globalization.CultureInfo.InvariantCulture)).Hour <= 24))
                {
                    bookingModel.GamingStations = (List<GamingStationDTO>)_gamingStationService.GetAll();
                    ViewBag.Error = "Du kan kun booke en tid indenfor vores åbningstid";
                    return View(bookingModel);
                }
                booking.StartTime = start;
                booking.EndTime = start.AddHours(double.Parse(bookingModel.EndTime, System.Globalization.CultureInfo.InvariantCulture));
                List<GamingStationDTO> allGamingStations = _gamingStationService.GetAll().ToList();
                if (bookingModel.GamingStations != null)
                {
                    for (int i = 0; i < bookingModel.GamingStations.Count(); i++)
                    {
                        if (bookingModel.GamingStations[i].isChecked)
                        {
                            booking.BookingLines.Add(new BookingLineDTO()
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
                    bookingModel.GamingStations = (List<GamingStationDTO>)_gamingStationService.GetAll();
                    ViewBag.Error = "Tidsrummet er optaget :(";
                    return View(bookingModel);
                }
            }
            catch
            {
                return View();
            }
        }
 
        /// <summary>
        /// Get metode til Delete view.
        /// </summary>
        /// <returns>Returnere et View hvor man kan se den booking man ønsker at slette</returns>
        // GET: BookingController/Delete/5
        public ActionResult Delete(string? bookingNo)
        {
            BookingDTO bookingToDelete = _bookingService.Get(bookingNo);
            return View(bookingToDelete);
        }

        /// <summary>
        /// Post metode til Delete en booking.
        /// </summary>
        /// <param name="bookingNo">string af booking nummeret</param>
        /// <param name="phoneNo">string af telefon nummeret</param>
        /// <returns>Returnere et ActionResult</returns>
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
    }
}
