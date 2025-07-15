using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppIdentityCore.Models;

namespace WebAppIdentityCore.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class RoleController : Controller
    {
        RoleRepository repository;
        public RoleController(RoleManager<IdentityRole> manager)
        {
            this.repository = new RoleRepository(manager);
        }
        public IActionResult Index()
        {
            return View(repository.GetRoles());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IdentityRole obj)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.Add(obj);
                if (result.Succeeded)
                {
                    return Redirect("/dashboard/role");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await repository.Delete(id);
            if (result != null && result.Succeeded)
            {
                return Redirect("/dashboard/role");
            }
            return Redirect("/dashboard/role/error");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await repository.GetRoleById(id);
            if (role != null)
            {
                return View(role);
            }
            return Redirect("/dashboard/role/error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole obj)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.Edit(obj);
                if (result.Succeeded)
                {
                    return Redirect("/dashboard/role");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return Redirect("/dashboard/role/error");
        }
    }
}
