using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppIdentityCore.Models;

namespace WebAppIdentityCore.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class UserController : Controller
    {
        UserRepository repository;
        RoleRepository roleRepository;

        public UserController(UserManager<IdentityUser> manager, RoleManager<IdentityRole> roleManager)
        {
            repository = new UserRepository(manager);
            roleRepository = new RoleRepository(roleManager);
        }

        public IActionResult Index()
        {
            return View(repository.GetUsers());
        }

        public async Task<IActionResult> Roles(string id)
        {
            ViewBag.user = await repository.GetUser(id);
            return View(roleRepository.GetRoles());
        }
    }
}
