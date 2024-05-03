using System.Xml.Serialization;

namespace ParcelManager.Models.DataTransfer
{
    [XmlRoot("Container")]
    public record ContainerDto
    {
        [XmlElement("Id")]
        public string Id { get; init; }
        [XmlElement("ShippingDate")]
        public DateTimeOffset ShippingDate { get; init; }
        // example is in lower case
        // use list for faster deserialization?
        [XmlElement("parcels")]
        public ParcelWrapperDto  ParcelWrapper { get; init; }
    }
}
