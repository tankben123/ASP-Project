using Microsoft.AspNetCore.Mvc;
using UploadApp.Models;

namespace UploadApp.Controllers
{
    public class UploadController : Controller
    {
        StoreContext context;

        public UploadController(StoreContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Uploads.ToList());
        }

        public IActionResult Multiple()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Multiple(IFormFile[] af)
        {
            if (af != null && af.Length > 0)
            {
                string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                List<Upload> list = new List<Upload>();
                foreach (var item in af)
                {
                    string fileName = Helper.RandomString(32) + Path.GetExtension(item.FileName);
                    using (Stream stream = new FileStream(Path.Combine(root, fileName), FileMode.Create))
                    {
                        item.CopyTo(stream);
                    } 
                    
                    list.Add(new Upload
                    {
                        OriginalName = item.FileName,
                        Url = fileName,
                        Type = item.ContentType,
                        Size = item.Length
                    });
                }
                context.Uploads.AddRange(list);
                int ret = context.SaveChanges();
                if (ret > 0)
                {
                    TempData["Message"] = $"{ret} files uploaded successfully.";
                    return Redirect("/upload");

                }    
            }


            return View();
        }
    }
}
