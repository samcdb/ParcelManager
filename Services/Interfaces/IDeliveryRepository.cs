using ParcelManager.Models;

namespace ParcelManager.Services.Interfaces
{
    // putting business logic in this layer for simplicity - if this was a bigger project this would just be CRUD and domain layer
    // would sit on top
    public interface IDeliveryRepository
    {
        Task AddParcels(IEnumerable<Parcel> parcels);
        Task UpdateParcel(Parcel parcel);
        // excluding lower, including upper
        Task<IEnumerable<Parcel>> GetPendingParcelsForDepartment(int departmentId);
        Task<IEnumerable<Parcel>> GetUnapprovedParcels();
        Task<Department> GetDepartment(int id);
        Task<IEnumerable<Department>> GetDepartments();
        Task AddDepartment(Department department);
        // for demo purposes
        Task AddDepartments(IEnumerable<Department> departments);
        Task DeleteDepartment(int id);
    }
}
