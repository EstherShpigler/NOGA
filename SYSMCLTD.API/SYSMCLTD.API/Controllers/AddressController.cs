using Microsoft.AspNetCore.Mvc;
using SYSMCLTD.API.Data;

namespace SYSMCLTD.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AddressController : Controller
    {
        private readonly SYSMCDBContext _sysdbcontext;



        public AddressController(SYSMCDBContext sysdbcontext)
        {
            _sysdbcontext = sysdbcontext;
        }

    }
}
