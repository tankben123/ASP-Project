using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Net.Mail;
using WebAppIdentityCore.Models;


namespace WebAppIdentityCore.Controllers
{
    public class HomeController : Controller
    {

        readonly IConfiguration configuration = null;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Contact(Contact obj)
        {
            bool ret = Helper.SendEmail(configuration, new Email
            {
                Subject = obj.Subject,
                Body = obj.Body,
                Address = obj.Email
            });

            if (ret)
                return Redirect("/");
            else
                return Redirect("/home/error");
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
