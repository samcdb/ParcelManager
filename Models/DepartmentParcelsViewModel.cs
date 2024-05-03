namespace ParcelManager.Models
{
    public class DepartmentParcelsViewModel
    {
        public IEnumerable<Parcel> Parcels { get; init; }
        public Department Department { get; init; }
    }
}
