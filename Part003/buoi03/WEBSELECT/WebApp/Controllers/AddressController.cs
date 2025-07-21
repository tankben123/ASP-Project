using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            return View(context.Addresses.Include(p=>p.Ward).ThenInclude(p=>p.Districts).ThenInclude(p=>p.Province).ToList());
        }

        [HttpPost]
        public IActionResult Add(Address obj)
        {
            if (ModelState.IsValid)
            {
                context.Addresses.Add(obj);
                int ret = context.SaveChanges();
                if (ret > 0)
                {
                    return Redirect("/address");
                }
                ModelState.AddModelError("", "Thêm địa chỉ không thành công");
            }

            return View(obj);
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


        [HttpPost]
        public IActionResult GetWards(byte id)
        {
            return Json(context.Wards.Where(p => p.DistrictId == id).ToList());
        }


    }
}
