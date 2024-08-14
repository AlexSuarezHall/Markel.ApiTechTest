using System.ComponentModel.DataAnnotations;

namespace Markel.Data.Models
{
    public class ClaimType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Name { get; set; }
    }
}
