using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        [JsonIgnore]

        public virtual ICollection<Contact> Customers { get; set; }

        [JsonIgnore]

        public virtual ICollection<Address> Address { get; set; }

        internal object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
