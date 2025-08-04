using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ImageController : BaseController
    {
        public IActionResult Index()
        {
            return View(Provider.Image.GetImages());
        }

        public IActionResult ClipBoard()
        {
            return View();
        }

        public IActionResult Icon()
        {
            return View();
        }

        public async Task<IActionResult?> Upload(IFormFile f)
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
                Image image = new Image
                {
                    ImageUrl = fileName,
                    Size = f.Length,
                    Type = f.ContentType,
                    OriginalName = f.FileName
                };
                int ret = await Provider.Image.Add(image);
                if (ret > 0)
                {
                    return Json(image); 
                }
            }
            return null;
        }

        public async Task<IActionResult?> Delete(int id)
        {
            if (id > 0)
            {
                Image? image = await Provider.Image.GetImageByIdAsync(id);
                if (image != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", image.ImageUrl);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    int ret = await Provider.Image.Delete(id);
                    if (ret > 0)
                    {
                        return Redirect("/image");
                    }
                }
            }
            return Redirect("/image/error");
        }

        public  IActionResult DragAndDrop()
        {
            return View();
        }   
    }
}
