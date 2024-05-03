using Microsoft.AspNetCore.Mvc;
using ParcelManager.Models;
using ParcelManager.Services.Interfaces;

namespace ParcelManager.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDeliveryRepository _repo;

        public DepartmentController(IDeliveryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Department> departments = await _repo.GetDepartments();

            // PURELY FOR DEMO PURPOSES
            // load example departments if departments table is empty
            if (departments.Count() == 0)
            {
                    await _repo.AddDepartments(new List<Department>{
                    new Department
                    {
                        Name = "Mail",
                        UpperWeight = 1,
                    },
                    new Department
                    {
                        Name = "Regular",
                        LowerWeight = 1,
                        UpperWeight = 10,
                    },
                    new Department
                    {
                        Name = "Heavy",
                        LowerWeight = 10,
                    },
                    new Department
                    {
                        Name = "Insurance",
                        IsApprover = true,
                        ValueThreshold = 1000
                    },
                });
                departments = await _repo.GetDepartments();
            }

            return View(departments);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            // there should be only one sign-off/approval department
            // since only one value threshold is used to check for approval during container processing
            if (department.IsApprover && (await _repo.GetDepartments()).FirstOrDefault(dep => dep.IsApprover) != null)
            {
                return View(department);
            }

            // lower threshold can't be higher than higher threshold
            if (department.LowerWeight > department.UpperWeight)
            {
                return View(department);
            }

            await _repo.AddDepartment(department);

            return RedirectToAction("Index");
        }

        [HttpPost("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteDepartment(id);
            
            return RedirectToAction("Index");
        }
    }
}
