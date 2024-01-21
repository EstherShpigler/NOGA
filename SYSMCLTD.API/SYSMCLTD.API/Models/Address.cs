using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SYSMCLTD.API.Models
{
    public class Address
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid? Id { get; set; }

        [ForeignKey("Customer")]

        public Guid? CustomerId { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public bool? IsDeleted { get; set; }

        public DateTime? Created { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }


    }
}
