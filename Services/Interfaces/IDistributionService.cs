using ParcelManager.Models.DataTransfer;

namespace ParcelManager.Services.Interfaces
{
    public interface IDistributionService
    {
        Task ProcessContainer(ContainerDto container);
    }
}
