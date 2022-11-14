using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.API.DTO;

namespace NetCafeUCN.API.Controllers
{
    public class GenericProductController<T> : Controller where T : Product
    {
        
    }
}
