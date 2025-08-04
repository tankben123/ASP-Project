using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoryController : BaseController
    {
        
        public IActionResult Index()
        {
            return View(Provider.Category.GetCategories());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IFormFile f, Category obj)
        {
            if (f != null && !string.IsNullOrEmpty(f.FileName))
            {
                string ext = Path.GetExtension(f.FileName);
                string fileName = Helper.randomString(32 - ext.Length) + ext;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    f.CopyTo(stream);
                }

                obj.ImageUrl = fileName;
            }
            int ret = await Provider.Category.Add(obj);
            if (ret > 0)
            {
                return Redirect("/category");
            }
            return View(obj);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile f, Category obj)
        {
            if (f != null && !string.IsNullOrEmpty(f.FileName))
            {
                string ext = Path.GetExtension(f.FileName);
                string fileName = Helper.randomString(32 - ext.Length) + ext;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    f.CopyTo(stream);
                }

                obj.ImageUrl = fileName;
            }
            int ret = await Provider.Category.Add(obj);
            if (ret > 0)
            {
                return Json(obj);
            }
            return Json(null);
        }

        public IActionResult Search(byte from = 0, byte to = 0)
        {
            if (from >= 0 && to > from )
            {
               return View(Provider.Category.Search(from, to));
            }

            return View(Provider.Category.GetCategories());

        }

        public IActionResult SearchAjax()
        {
            return View(Provider.Category.GetCategories());
        }
        [HttpPost]
        public IActionResult SearchAjax(byte from = 0, byte to = 0)
        {
            if (from >= 0 && to > from)
            {
                return Json(Provider.Category.Search(from, to));
            }

            return Json(Provider.Category.GetCategories());
        }
    }
}
