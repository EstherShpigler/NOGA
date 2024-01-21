using System.ComponentModel.DataAnnotations.Schema;

namespace SYSMCLTD.API.Models
{
    public class AddressModel
    {
        public Guid? Id { get; set; }
        public Guid? CustomerId { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? Created { get; set; }
    }

    public class ContactModel
    {
        public Guid? Id { get; set; }
        public string? FullNameContact { get; set; }
        public int? OfficeNumber { get; set; }
        public string? Email { get; set; }
        public int? CustomerId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? Created { get; set; }
    }

    public class CustomerModel
    {
        public Guid? Id { get; set; }
        public string? FullName { get; set; }

        public int? IdNum { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? Created { get; set; }

        public List<ContactModel> Contectsmodel { get; set; }
        public List<AddressModel> AddressesModels { get; set; }


    }
}
