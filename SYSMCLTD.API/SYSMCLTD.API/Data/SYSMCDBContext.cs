using Microsoft.EntityFrameworkCore;
using SYSMCLTD.API.Models;

namespace SYSMCLTD.API.Data
{
    public class SYSMCDBContext : DbContext
    {
        public SYSMCDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> customer { get; set; }
      
        public DbSet<Contact> contact { get; set; }

        public DbSet<Address> address { get; set; }




     



    }
}