using Microsoft.EntityFrameworkCore;
using ParcelManager.DataAccess;
using ParcelManager.Models;
using ParcelManager.Services.Interfaces;

namespace ParcelManager.Services
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ApplicationDbContext _context;

        public DeliveryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddDepartment(Department department)
        {
            _context.Department.Add(department);
            await _context.SaveChangesAsync();
        }

        // for demo purposes
        public async Task AddDepartments(IEnumerable<Department> departments)
        {
            _context.Department.AddRange(departments);
            await _context.SaveChangesAsync();
        }

        public async Task AddParcels(IEnumerable<Parcel> parcels)
        {
            _context.Parcel.AddRange(parcels);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartment(int id)
        {
            var departmentToDelete = new Department { Id = id };
            _context.Attach(departmentToDelete);
            _context.Department.Remove(departmentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await _context.Department.SingleAsync(dep => dep.Id == id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Department.ToListAsync();
        }

        // get parcels that have been approved by an approving (insurance) department (if one exists)
        // and that have not yet been processed by a department
        public async Task<IEnumerable<Parcel>> GetPendingParcelsForDepartment(int departmentId)
        {
            Department dep = await _context.Department.SingleAsync(d => d.Id == departmentId);
            double? lowerBound = dep.LowerWeight;
            double? upperBound = dep.UpperWeight;

            IQueryable<Parcel> query = _context.Parcel.Where(p => p.IsApproved && !p.IsProcessed);

            // build query based on conditions
            if (lowerBound != null)
            {
                query = query.Where(p => p.Weight > lowerBound);
            }

            if (upperBound != null)
            {
                query = query.Where(p => p.Weight <= upperBound);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Parcel>> GetUnapprovedParcels()
        {
            return await _context.Parcel.Where(p => !p.IsApproved).ToListAsync();
        }

        public async Task UpdateParcel(Parcel parcel)
        {
            _context.Update(parcel);
            await _context.SaveChangesAsync();
        }
    }
}
