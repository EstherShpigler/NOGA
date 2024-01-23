using System.ComponentModel.DataAnnotations.Schema;

namespace SYSMCLTD.API.Models
{
    public class ContactRequest
    {


        public string? FullNameContact { get; set; }
        public int? OfficeNumber { get; set; }
        public string? Email { get; set; }

        public Guid? CustomerId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? Created { get; set; }

    }
}
