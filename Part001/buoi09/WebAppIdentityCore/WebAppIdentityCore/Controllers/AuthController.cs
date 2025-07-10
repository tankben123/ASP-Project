using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppIdentityCore.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAppIdentityCore.Controllers
{
    public class AuthController : Controller
    {
        readonly UserRepository repository;
        readonly SignInManager<IdentityUser> signInManager;

        public AuthController(UserManager<IdentityUser> manager, SignInManager<IdentityUser> signInManager)
        {
            this.repository = new UserRepository(manager);
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel obj)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.Add(obj);
                if (result.Succeeded)
                    return Redirect("/auth/login");
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("error", error.Description);
                    }
                }
            }
            else 
            {
                ModelState.AddModelError("error", "Please input");
            }

                return View(obj);
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel obj)
        {
            if (ModelState.IsValid)
            {
                var user = await repository.Login(obj);
                if (user != null)
                {
                    //Lưu Cookie 
                    //Miss Roles
                    var result = await signInManager.PasswordSignInAsync(user, obj.P, obj.R, true);
                    if (result.Succeeded)
                    {
                        return Redirect("/auth");
                    }
                    else
                    {
                        ModelState.AddModelError("error", "Login failed, please try again");
                    }    

                }
                else
                {
                    ModelState.AddModelError("error", "Username or Password invalid");
                }
            }
            else
            {
                ModelState.AddModelError("error", "Please input");
            }
            return View(obj);
        }
    }
}
