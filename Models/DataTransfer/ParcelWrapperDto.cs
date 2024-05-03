using System.Xml.Serialization;

namespace ParcelManager.Models.DataTransfer
{
    public record ParcelWrapperDto
    {
        [XmlElement("Parcel")]
        public List<ParcelDto> Parcels { get; init; }
    }
}
