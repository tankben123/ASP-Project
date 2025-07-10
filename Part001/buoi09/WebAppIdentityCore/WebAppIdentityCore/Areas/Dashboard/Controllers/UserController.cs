using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppIdentityCore.Models;

namespace WebAppIdentityCore.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class UserController : Controller
    {
        UserRepository repository;

        public UserController(UserManager<IdentityUser> manager)
        {
            repository = new UserRepository(manager);
        }

        public IActionResult Index()
        {
            return View(repository.GetUsers());
        }
    }
}
