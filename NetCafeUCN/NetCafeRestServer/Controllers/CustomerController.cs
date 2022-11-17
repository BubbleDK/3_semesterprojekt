﻿using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private INetCafeDataAccess<Customer> dataAccess;


        public CustomerController(INetCafeDataAccess<Customer> dataAccess)
        {
            this.dataAccess = dataAccess;

        }

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            return Ok(dataAccess.GetAll());
        }

        // GET api/<ProductController>/74747
        [HttpGet]
        [Route("{phoneNo}")]
        public ActionResult<Person> Get(string phoneNo)
        {
            var product = dataAccess.Get(phoneNo);
            if (product == null) { return NotFound(); }

            return Ok(product);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Customer p)
        {

            return Ok(dataAccess.Add(p));
        }

        // PUT api/<ProductController>/
        [HttpPut]
        public ActionResult<bool> Update(Customer person)
        {
            return Ok(dataAccess.Update(person));
        }

        // DELETE api/<CustomerController>/40559810
        [HttpDelete("{phoneNo}")]
        public ActionResult<bool> Delete(string phoneNo)
        {
            if (dataAccess.Remove(phoneNo))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}


