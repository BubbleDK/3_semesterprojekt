using DataAccessLayer.DAO;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCafeUCN.API.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class PersonController : ControllerBase
        {
            private INetCafeDataAccess<Person> dataAccess;

            public PersonController(INetCafeDataAccess<Person> dataAccess)
            {
                this.dataAccess = dataAccess;
            }

            // GET: api/<PersonController>
            [HttpGet]
            public ActionResult<IEnumerable<Person>> Get()
            {
                return Ok(dataAccess.GetAll());
            }

            // GET api/<PersonController>/40559810
            [HttpGet]
            [Route("{phoneNo}")]
            public ActionResult<Person> Get(string phoneNo)
            {
                var person = dataAccess.Get(phoneNo);
                if (person == null) { return NotFound(); }
                return Ok(person);
            }

            // POST api/<PersonController>
            [HttpPost]
            public ActionResult<bool> Add(Person person)
            {
                return Ok(dataAccess.Add(person));
            }

            // PUT api/<PersonController>/
            [HttpPut]
            public ActionResult<bool> Update(Person person)
            {
                return Ok(dataAccess.Update(person));
            }

            // DELETE api/<PersonController>/40559810
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

