using System.Xml.Serialization;

namespace ParcelManager.Models.DataTransfer
{
    public record RecipientDto
    {
        [XmlElement("Name")]
        public string Name { get; init; }
        [XmlElement("Address")]
        public AddressDto Address { get; init; }
    }
}
