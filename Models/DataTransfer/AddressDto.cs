using System.Xml.Serialization;

namespace ParcelManager.Models.DataTransfer
{
    public record AddressDto
    {
        [XmlElement("Street")]
        public string Street { get; init; }
        [XmlElement("HouseNumber")]
        public int HouseNumber { get; init; }
        [XmlElement("PostalCode")]
        public string PostalCode { get; init; }
        [XmlElement("City")]
        public string City { get; init; }
    }
}