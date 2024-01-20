using Microsoft.AspNetCore.Mvc;

namespace SYSMCLTD.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
