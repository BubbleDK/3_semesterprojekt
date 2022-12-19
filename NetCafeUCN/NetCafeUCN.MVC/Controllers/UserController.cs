using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Authentication;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Models.DTO;
using NetCafeUCN.MVC.Services;
using System.Dynamic;
using System.Linq;

namespace NetCafeUCN.MVC.Controllers
{
    /// <summary>
    /// UserController klasse, som nedarver fra Controller
    /// </summary>
    [Authorize]
    public class UserController : Controller
    {
        readonly INetCafeDataAccessService<CustomerDto> _customerService;
        readonly INetCafeDataAccessService<EmployeeDto> _employeeService;

        /// <summary>
        /// UserController constructor
        /// </summary>
        /// <param name="customerService">Sæt den customer service som skal bruges i klassen</param>
        /// <param name="employeeService">Sæt den employee service som skal bruges i klassen</param>
        public UserController(INetCafeDataAccessService<CustomerDto> customerService, INetCafeDataAccessService<EmployeeDto> employeeService)
        {
            _customerService = customerService;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get metode til index view
        /// </summary>
        /// <returns>Et view af alle customers og employees</returns>
        // GET: PersonController
        [Authorize("Administrator")]
        public ActionResult Index()
        {
            CustomerEmployeeViewModel viewModel = new CustomerEmployeeViewModel();
            viewModel.customers = _customerService.GetAll();
            viewModel.employees = _employeeService.GetAll();
            
            return View(viewModel);
        }

        /// <summary>
        /// Get metode til details view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Get metode til create view
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post metode, til at oprette en ny customer
        /// </summary>
        /// <param name="customer">CustomerDto objekt ud fra form værdier</param>
        /// <returns>Et view</returns>
        // POST: PersonController/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]CustomerDto customer)
        {
            customer.IsActive = true;
            customer.PersonType = "Customer";
            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                ViewBag.Error = "Bruger ikke oprettet - fejl i oplysninger";
                RedirectToAction("Create");
            }
            else
            {
                try
                {
                    customer.Password = BCryptTool.HashPassword(customer.Password);
                    if (_customerService.Add(customer) == true)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        ViewBag.Error = "Telefonnummer eller email er allerede oprettet i systemet";
                        return View();
                    }
                }
                catch (Exception)
                {
                    ViewBag.Error = "Bruger ikke oprettet";
                    RedirectToAction("Create");
                }
            }
            return View();
           
        }

        /// <summary>
        /// Get metode til edit view
        /// </summary>
        /// <param name="phone">string af telefon nummeret på den ønskede person som skal ændres</param>
        /// <returns>Et view med enten EditCustomer eller EditEmployee</returns>
        // GET: PersonController/Edit/5
        public ActionResult Edit(string phone)
        {
            if (_customerService.GetAll().ToList().First(customer => customer.Phone == phone) != null)
            {
                //Customer c = customerService.GetAll().ToList().First(customer => customer.Phone == phone);
                return RedirectToAction("EditCustomer");
            }else if(_employeeService.GetAll().ToList().First(employee => employee.Phone == phone) != null)
            {
                //Employee e = employeeService.GetAll().ToList().First(employee => employee.Phone == phone);
                return RedirectToAction("EditEmployee");
            }
            else
            {
                return RedirectToAction("Index");
            }
            //return View();
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: PersonController/Edit/5
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

        /// <summary>
        /// Get metode til delete view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
