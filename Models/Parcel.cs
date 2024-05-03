using System.ComponentModel.DataAnnotations;

namespace ParcelManager.Models
{
    public class Parcel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ContainerId { get; set; }
        [Required]
        public string RecipientName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public decimal Value { get; set; }
        public bool IsApproved { get; set; } = true;
        public bool IsProcessed { get; set; } = false;
        public DateTime CreatedAt{ get; set; } = DateTime.UtcNow;
        public DateTimeOffset ShippingDate { get; set; }
    }
}
