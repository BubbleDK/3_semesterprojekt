﻿using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private INetCafeDataAccess<Product> dataAccess;


        public ProductController(INetCafeDataAccess<Product> dataAccess)
        {
            this.dataAccess = dataAccess;

        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(dataAccess.GetAll());
        }

        // GET api/<ProductController>/74747
        [HttpGet]
        [Route("{productNo}")]
        public ActionResult<Product> Get(string productNo)
        {
            var product = dataAccess.Get(productNo);
            if (product == null) { return NotFound(); }


            if (product.Type == "gamingstation")
            {
                product = product as GamingStation;
            }
            else
            {
                product = product as Consumable;
            }
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Product p)
        {

            return Ok(dataAccess.Add(p));
        }

        // PUT api/<ProductController>/
        [HttpPut]
        public ActionResult<bool> Update(Product product)
        {
            return Ok(dataAccess.Update(product));
        }

        // DELETE api/<ProductController>/40559810
        [HttpDelete("{productNo}")]
        public ActionResult<bool> Delete(string productNo)
        {
            if (dataAccess.Remove(productNo))
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
