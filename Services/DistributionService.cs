using ParcelManager.Models;
using ParcelManager.Models.DataTransfer;
using ParcelManager.Services.Interfaces;

namespace ParcelManager.Services
{
    public class DistributionService : IDistributionService
    {
        private readonly IDeliveryRepository _repo;

        public DistributionService(IDeliveryRepository repo)
        {
            _repo = repo;
        }
        public async Task ProcessContainer(ContainerDto container)
        {
            decimal valueThreshold = 0;
            // assume that there is only one approval department at most
            Department approvalDepartment = (await _repo.GetDepartments()).FirstOrDefault(dep => dep.IsApprover);

            // if there is an approval department - use its value threshold
            if (approvalDepartment != null)
            {
                valueThreshold = (decimal)approvalDepartment.ValueThreshold;
            }

            // could have had container be another entity
            IEnumerable<Parcel> parcels = container.ParcelWrapper.Parcels.Select(p => {

                var parcel = new Parcel
                {
                    ContainerId = container.Id,
                    RecipientName = p.Recipient.Name,
                    Street = p.Recipient.Address.Street,
                    HouseNumber = p.Recipient.Address.HouseNumber,
                    PostalCode = p.Recipient.Address.PostalCode,
                    City = p.Recipient.Address.City,
                    Weight = p.Weight,
                    Value = p.Value,
                    ShippingDate = container.ShippingDate,
                };

                // parcels are approved by default - unless there is an approval department
                if (approvalDepartment != null)
                {
                    parcel.IsApproved = p.Value <= approvalDepartment.ValueThreshold;
                }

                return parcel;
            });
            await _repo.AddParcels(parcels);
        }
    }
}
