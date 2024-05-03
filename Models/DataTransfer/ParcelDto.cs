using System.Xml.Serialization;

namespace ParcelManager.Models.DataTransfer
{
    public record ParcelDto
    {
        [XmlElement("Receipient")]
        public RecipientDto Recipient { get; init; }
        [XmlElement("Weight")]
        public double Weight { get; init; }
        [XmlElement("Value")]
        public decimal Value { get; init; }
    }
}
