using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebUpload.Models;

namespace WebUpload.Controllers
{
    public class UploadController : Controller
    {

        public ImageRepository repository;
        public UploadController(ImageRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.GetImages());
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
                string fileName = Helper.RanDomString(32 - ext.Length) + ext;

                Image image = new Image
                {
                    Url = fileName,
                    OriginalName = f.FileName,
                    Size = f.Length,
                    Type = f.ContentType
                };

                if (repository.Add(image) > 0)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        f.CopyTo(stream);
                    }
                }
            }
            return Redirect("/upload");
        }

        public IActionResult Details(int id)
        {
            return View(repository.GetImage(id));
        }

        [HttpPost]
        public IActionResult Download(int id)
        {
            Image? image = repository.GetImage(id);
            if (image != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", image.Url);
                Stream stream = new FileStream(path, FileMode.Open);

                return File(stream, "application/octet-stream", image.OriginalName);
            }  
            return NotFound();
        }

    }
}
