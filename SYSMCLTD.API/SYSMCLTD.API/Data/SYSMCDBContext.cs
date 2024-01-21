using Microsoft.EntityFrameworkCore;
using SYSMCLTD.API.Models;

namespace SYSMCLTD.API.Data
{
    public class SYSMCDBContext : DbContext
    {

        public SYSMCDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CustomerModel> customer { get; set; }
        public DbSet<ContactModel> contact { get; set; }

        public DbSet<AddressModel> address { get; set; }




     



    }
}