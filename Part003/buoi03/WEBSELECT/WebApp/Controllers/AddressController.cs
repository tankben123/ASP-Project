using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AddressController : Controller
    {
        OganiContext context;
        public AddressController(OganiContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.provinces = new SelectList(context.Provinces.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Districts(byte id)
        {
            return Json(context.Districts.Where(p => p.ProvinceId == id).ToList());
        }
    }
}
