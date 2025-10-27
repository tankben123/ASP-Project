using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SuperStoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
