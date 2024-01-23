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

     //הוספת איש קשר ללקוח מסוים
        [HttpPost]

        public async Task<IActionResult> AddContact([FromBody] ContactRequest cr)
        {
            var contact = new Contact();
            contact.FullNameContact = cr.FullNameContact;
            contact.OfficeNumber = cr.OfficeNumber;
            contact.Email = cr.Email;
            contact.IsDeleted = false;
            contact.Created = DateTime.Now;
            contact.CustomerId = cr.CustomerId;
            await _sysdbcontext.contact.AddAsync(contact);
            await _sysdbcontext.SaveChangesAsync();

            return Ok("ok");
        }
    }
}
