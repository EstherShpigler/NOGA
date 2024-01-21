using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SYSMCLTD.API.Data;
using SYSMCLTD.API.Models;

namespace SYSMCLTD.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly SYSMCDBContext _sysdbcontext;

        private  CustomerModel _customer = new CustomerModel();


        public CustomerController(SYSMCDBContext sysdbcontext)
        {
            _sysdbcontext = sysdbcontext;
        }
        public CustomerController(CustomerModel customerr)
        {
            _customer = customerr;
        }

        //Get All
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customer =( await _sysdbcontext.customer.ToListAsync()).Where(x=>x.IsDeleted==false);
            return Ok(customer);
        }
        ////שליפת לקוח ונתוניו לפי ID
        //[HttpGet]
        //[Route("{id:guid}")]
        //[ActionName("GetCustomer")]
        //public async Task<IActionResult> GetCustomer([FromRoute] Guid id)
        //{
        //    var customer = (await _sysdbcontext.customer.ToListAsync(x => x.Id == id)).Where(x => x.IsDeleted == false);
        //    if (customer != null)
        //    {
        //        return Ok(customer);
        //    }
        //    return NotFound("Customer Not Found");
        //}


        //Add Task--  הוספת לקוח
        [HttpPost]

        public async Task<IActionResult> AddCustomer([FromBody] CustomerModel _customer)
        {

            var c = await _sysdbcontext.customer.AddAsync(_customer);
            
            await _sysdbcontext.SaveChangesAsync();

            return Ok(c);
        }
        //עדכון לקוח 
        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, [FromBody] Customer _customer)
        {
            var _update = await _sysdbcontext.customer.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (_update != null)
            {
                _update.FullName = _customer.FullName;
                _update.IdNum = _customer.IdNum;
                _update.IsDeleted = _customer.IsDeleted;
                _update.Created = _customer.Created;
                await _sysdbcontext.SaveChangesAsync();
                return Ok(_update);
            }
            return NotFound("Customer Not Found");

        }
        //מחיקת לקוח 
        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            var _update = await _sysdbcontext.customer.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (_update != null)
            {
                _update.IsDeleted = true;
                await _sysdbcontext.SaveChangesAsync();
                return Ok();
            }
            return NotFound("Customer Not Found");

        }
    }
}
