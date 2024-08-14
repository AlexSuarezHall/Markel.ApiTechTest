using System.ComponentModel.DataAnnotations;

namespace Markel.Data.Models
{
    public class Company
    {
        public Company()
        {
            Claims = new List<Claim>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address1 { get; set; }

        [MaxLength(100)]
        public string Address2 { get; set; }

        [MaxLength(100)]
        public string Address3 { get; set; }

        [MaxLength(20)]
        public string Postcode { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        public bool Active { get; set; }

        public DateTime InsuranceDate { get; set; }

        public bool HasActiveInsurancePolicy => Claims.Any();

        public virtual ICollection<Claim> Claims { get; set; }
    }
}
