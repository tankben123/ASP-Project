using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppIdentityCore.Models;

namespace WebAppIdentityCore.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    [Route("dashboard/{controller=home}/{action=index}/{id?}")]
    public class UserController : Controller
    {
        UserRepository repository;
        RoleRepository roleRepository;

        public UserController(UserManager<IdentityUser> manager, RoleManager<IdentityRole> roleManager)
        {
            repository = new UserRepository(manager, roleManager);
            roleRepository = new RoleRepository(roleManager);
        }

        public IActionResult Index()
        {
            return View(repository.GetUsers());
        }

        public async Task<IActionResult> Roles(string id)
        {
            List<IdentityRole> list = roleRepository.GetRoles();
            IList<string>? roles = await repository.GetRolesByUser(id);

            ViewBag.user = await repository.GetUser(id);

            if (list != null && roles != null)
            {
                return View(list.Select(p =>
                {
                    return new RoleChecked
                    {
                        Id = p.Id,
                        Name = p.Name,
                        IsChecked = roles.Any(r => r.Equals(p.Name))
                    };
                }).ToList());
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(IdentityUserRole<string> obj)
        {
            var result = await repository.Add(obj);
            if (result != null)
                return Json(obj);

            return NotFound();
        }
    }
}
