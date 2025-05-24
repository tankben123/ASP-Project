using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebUpload.Models;

namespace WebUpload.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile f)
        {
            if (f != null &&! string.IsNullOrEmpty(f.FileName))
            {
                string ext = Path.GetExtension(f.FileName);
                string fileNane = Helper.RanDomString(32 - ext.Length) + ext;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileNane);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    f.CopyTo(stream);
                }    
            }
            return View();
        }
    }
}
