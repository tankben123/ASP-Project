using Microsoft.AspNetCore.Mvc;

namespace WebAppIdentityCore.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
