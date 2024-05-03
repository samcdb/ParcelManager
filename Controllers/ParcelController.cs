using Microsoft.AspNetCore.Mvc;
using ParcelManager.Models;
using ParcelManager.Services.Interfaces;

namespace ParcelManager.Controllers
{
    [Route("[controller]")]
    public class ParcelController : Controller
    {
        private readonly IDeliveryRepository _repo;

        public ParcelController(IDeliveryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("ForDepartment/{id}")]
        public async Task<IActionResult> ForDepartment(int id)
        {
            var department = await _repo.GetDepartment(id);

            // need a viewmodel to also store departmentId state
            // so that future actions on this page can redirect to the same page
            var viewModel = new DepartmentParcelsViewModel
            {
                Parcels = department.IsApprover ? await _repo.GetUnapprovedParcels() : await _repo.GetPendingParcelsForDepartment(id),
                Department = department
            };

            return View(viewModel);
        }

        // need departmentId to redirect back to same page
        [HttpPost("Update/{departmentId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int departmentId, Parcel parcel)
        {
            await _repo.UpdateParcel(parcel);

            return RedirectToAction("ForDepartment", new { id = departmentId });
        }
    }
}
