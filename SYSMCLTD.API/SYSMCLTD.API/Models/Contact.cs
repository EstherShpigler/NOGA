using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SYSMCLTD.API.Models
{
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid? Id { get; set; }

        public string? FullNameContact { get; set; }
        public int? OfficeNumber { get; set; }

        public string? Email { get; set; }

        [ForeignKey("Customer")]

        public int? CustomerId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? Created { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
