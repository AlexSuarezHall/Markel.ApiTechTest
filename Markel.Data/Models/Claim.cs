using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Markel.Data.Models
{
    public class Claim
    {

        [MaxLength(20)]
        [Key]
        [Required]
        public string UCR { get; set; }

        [ForeignKey(nameof(Company))]
        [Required]
        public int CompanyId { get; set; }

        [ForeignKey(nameof(ClaimType))]
        [Required]
        public int ClaimTypeId { get; set; }

        public DateTime ClaimDate { get; set; }

        public DateTime LossDate { get; set; }

        [MaxLength(100)]
        [Required]
        public string AssuredName { get; set; }

        public decimal IncurredLoss { get; set; }

        public bool Closed { get; set; }

        public double ClaimAgeInDays => Math.Round((DateTime.UtcNow - ClaimDate).TotalDays);

    }
}
