using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SYSMCLTD.API.Models
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid? Id { get; set; }
        public string? FullName { get; set; }

        public int? IdNum { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? Created { get; set; }
    }
}
