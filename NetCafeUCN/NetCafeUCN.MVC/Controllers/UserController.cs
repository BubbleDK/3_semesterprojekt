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
    [Authorize]
    public class UserController : Controller
    {
        INetCafeDataAccess<Customer> customerService = new CustomerService("https://localhost:7197/api/Customer");
        INetCafeDataAccess<Employee> employeeService = new EmployeeService("https://localhost:7197/api/Employee");
        // GET: PersonController
        public ActionResult Index()
        {
            CustomerEmployeeViewModel viewModel = new CustomerEmployeeViewModel();
            viewModel.customers = customerService.GetAll();
            viewModel.employees = employeeService.GetAll();
            
            return View(viewModel);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [AllowAnonymous]
        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: PersonController/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]Customer customer)
        {
            customer.IsActive = true;
            customer.PersonType = "Customer";
            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                ViewBag.ErrorMessage = "Bruger ikke oprettet - fejl i oplysninger";
            }
            else
            {
                try
                {
                    customer.Password = BCryptTool.HashPassword(customer.Password);
                    customerService.Add(customer);
                    return RedirectToAction("Login", "Account");
                }
                catch (Exception)
                {

                    ViewBag.ErrorMassage = "Bruger ikke oprettet";
                }
            }
            return View();
           
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(string phone)

            
        {
            if (customerService.GetAll().ToList().First(customer => customer.Phone == phone) != null)
            {
                //Customer c = customerService.GetAll().ToList().First(customer => customer.Phone == phone);
                return RedirectToAction("EditCustomer");
            }else if(employeeService.GetAll().ToList().First(employee => employee.Phone == phone) != null)
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

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

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
