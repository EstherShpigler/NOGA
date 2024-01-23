
namespace SYSMCLTD.API.Models
{
    public class CustomerAddressRequest 
    {
        public Guid? CustomerId { get; set; }

        public Guid? Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }

    }
}

