using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SYSMCLTD.API.Data;
using SYSMCLTD.API.Models;
using System.Net;

namespace SYSMCLTD.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly SYSMCDBContext _sysdbcontext;

        public CustomerController(SYSMCDBContext sysdbcontext)
        {
            _sysdbcontext = sysdbcontext;
        }


        //Get All
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customer = await _sysdbcontext.customer.Where(x => x.IsDeleted == false).ToListAsync();
            return Ok(customer);
        }
        //Get Id
        //שליפת לקוח ונתוניו לפי ID
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid id)
        {
            var customer = await _sysdbcontext.customer
                .Include(a => a.Address).Include(c=>c.Customers)
                .Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound("Customer Not Found");
        }


        //Add Customer--  הוספת לקוח
        [HttpPost]

        public async Task<IActionResult> AddCustomer([FromBody] CustomerRequest c)
        {
            var customer = new Customer();
            var check = await _sysdbcontext.customer.FirstOrDefaultAsync(x => x.FullName == c.FullName);

            if (check!=null)
            {
                return Conflict("name exists");
            }
            customer.FullName = c.FullName;
            customer.IdNum = c.IdNum;
            customer.IsDeleted = false;
            customer.Created = DateTime.Now;
            customer.Address = new List<Address>();
            customer.Customers = new List<Contact>();
            foreach (var cr in c.Contacts)
            {
                customer.Customers.Add(
                    new Contact
                    {
                       FullNameContact = cr.FullNameContact,
                       OfficeNumber = cr.OfficeNumber,
                       Email = cr.Email,
                       IsDeleted = false,
                       Created = DateTime.Now,
                       CustomerId = cr.CustomerId
                    });
            }
            foreach (var add in c.Address)
            {
                customer.Address.Add(
                    new Address
                    {
                        CustomerId =add.CustomerId,
                        City = add.City,
                        Street = add.Street,
                        Created = DateTime.Now,
                        IsDeleted = false
                    });
            }



           await _sysdbcontext.customer.AddAsync(customer);
            await _sysdbcontext.SaveChangesAsync();

            return Ok("ok");
        }
        //עדכון לקוח 
        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] CustomerRequest _customer)

        {
            var _update = await _sysdbcontext.customer.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (_update != null)
            {

                var check = await _sysdbcontext.customer.FirstOrDefaultAsync(x => x.FullName == _customer.FullName && x.Id != id);

                if (check != null)
                {
                    return Conflict("name exists");
                }
                _update.FullName = _customer.FullName;
                _update.IdNum = _customer.IdNum;
                _update.Address = new List<Address>();
                _update.Customers = new List<Contact>();

                foreach (var add in _customer.Address)
                {
                    var address = _update.Address.FirstOrDefault(x => x.Id == add.Id);

                    if(address == null)
                    {
                        _update.Address.Add(new Address() 
                        { Street = add.Street, City = add.City, Created = DateTime.Now });

                    }
                    else
                    {
                        address.Street = add.Street;
                        address.City = add.City;
                        address.Created = DateTime.Now;
                    }

                }

                foreach (var con in _customer.Contacts)
                {
                    var contact = _update.Customers.FirstOrDefault(x => x.Id == con.CustomerId);
                    if(contact == null)
                    { 
                      _update.Customers.Add(new Contact()
                      { FullNameContact=con.FullNameContact,OfficeNumber=con.OfficeNumber,Email=con.Email,Created=DateTime.Now, });
                    }
                    else
                    {
                        contact.FullNameContact = con.FullNameContact;
                        contact.OfficeNumber = con.OfficeNumber;
                        contact.Email = con.Email;
                        contact.Created = DateTime.Now;
                    }
                }

                    await _sysdbcontext.SaveChangesAsync();
                return Ok(_update);
            }
            return NotFound("Customer Not Found");

        }
        //מחיקת לקוח 
        [HttpDelete]
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