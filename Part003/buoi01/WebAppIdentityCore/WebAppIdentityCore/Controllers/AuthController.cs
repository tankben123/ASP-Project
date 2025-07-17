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

        readonly IConfiguration configuration = null;
        public AuthController(UserManager<IdentityUser> manager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            this.repository = new UserRepository(manager, roleManager);
            this.signInManager = signInManager;
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
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
                {
                    string token = await repository.GenerateEmailConfirmationTokenAsync(obj.Email);

                    if (token != null)
                    {
                        string url = Url.Action("Confirm", "Auth", new { token, obj.Email }, HttpContext.Request.Scheme);
                        bool ret = Helper.SendEmail(configuration, new Email
                        {
                            Subject = "Welcome",
                            Body = string.Format("<a href=\"{0}\">Click link comfirm email</a>", url),
                            Address = obj.Email,
                            IsBodyHtml = true
                        });

                        if (ret)
                        {
                            TempData["msg"] = $"You register success, Please check your mail: {obj.Email}";
                            return Redirect("/auth/success");
                        }
                        ModelState.AddModelError("error", "Email invalid");
                    }
                }
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

        public IActionResult Success()
        {
            return View();
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

        public async Task<IActionResult> Confirm(string token, string email)
        {
            IdentityResult? result = await repository.ConfirmEmailAsync(email, token);
            if (result != null && result.Succeeded)
            {
                return Redirect("/auth/login");
            }
            return Redirect("/auth/error");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/auth/login");
        }

        public IActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Forgot(Forgot obj)
        {
            string? token = await repository.GeneratePasswordResetToken(obj.Email);
            if (token != null)
            {
                string url = Url.Action("ResetPassword", "Auth", new { token, obj.Email }, HttpContext.Request.Scheme);
                bool ret = Helper.SendEmail(configuration, new Email
                {
                    Subject = "Reset Password",
                    Body = string.Format("<a href=\"{0}\">Click link reset password</a>", url),
                    Address = obj.Email,
                    IsBodyHtml = true
                });
                if (ret)
                {
                    TempData["msg"] = $"Please check your mail: {obj.Email}";
                    return Redirect("/auth/success");
                }
            }
            ModelState.AddModelError("error", "Email not found");
            return View(obj);
        }

        public IActionResult ResetPassword(string token, string email)
        {
            return View();
        }
    }
}
