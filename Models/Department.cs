using System.ComponentModel.DataAnnotations;

namespace ParcelManager.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public double? LowerWeight { get; set; }
        [Range(0, int.MaxValue)]
        public double? UpperWeight { get; set; }
        [Range(0, int.MaxValue)]
        public decimal? ValueThreshold { get; set; }
        public bool IsApprover { get; set; } = false;
        public DateTime CreatedAt{ get; set; } = DateTime.UtcNow;
    }
}
