using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SYSMCLTD.API.Models
{
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid? Id { get; set; }

        public string? FullName { get; set; }
        public int? OfficeNumber { get; set; }

        public string? Email { get; set; }

        [ForeignKey("Customer")]

        public int? CustomerId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? Created { get; set; }
    }
}
