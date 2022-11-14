using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.DTO;

namespace NetCafeUCN.API.Controllers
{
    public interface ICustomerController
    {
        ActionResult<bool> Add([FromBody] Customer p);
        ActionResult<bool> Delete(string phoneNo);
        ActionResult<Person> Get(string phoneNo);
        ActionResult<IEnumerable<Customer>> GetAll();
        ActionResult<bool> Update(Customer person);
    }
}