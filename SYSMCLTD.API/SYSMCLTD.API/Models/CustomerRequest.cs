namespace SYSMCLTD.API.Models
{
    public class CustomerRequest
    {

        public string? FullName { get; set; }

        public int? IdNum { get; set; }

        public virtual ICollection<ContactRequest> Contacts { get; set; }


        public virtual ICollection<CustomerAddressRequest> Address { get; set; }

    }



}
