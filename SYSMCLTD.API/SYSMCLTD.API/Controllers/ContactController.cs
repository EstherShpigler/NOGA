using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SYSMCLTD.API.Data;
using SYSMCLTD.API.Models;

namespace SYSMCLTD.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ContactController : Controller
    {
        private readonly SYSMCDBContext _sysdbcontext;



        public ContactController(SYSMCDBContext sysdbcontext)
        {
            _sysdbcontext = sysdbcontext;
        }

        //שליפת אנשי הקשר של לקוח מסוים
        //[HttpGet]
        //[Route("{id:guid}")]
        //[ActionName("GetContact")]
        //public async Task<IActionResult> GetContact([FromRoute] Guid id)
        //{
        //    var _contact = await _sysdbcontext.ContactModel.contact.ToListAsync(x => x.CustomerId == id && x.IsDeleted == false);
        //    if (_contact != null)
        //    {
        //        return Ok(_contact);
        //    }
        //    return NotFound("Contact Not Found");
        //}
    }
}
