using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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


        Upload DoUpload(IFormFile f, string root)
        {
            string ext = Path.GetExtension(f.FileName);
            string fileName = Helper.RandomString(32 - ext.Length) + ext;

            using (Stream stream = new FileStream(Path.Combine(root, fileName), FileMode.Create))
            {
                f.CopyTo(stream);
            }

            return new Upload
            {
                OriginalName = f.FileName,
                Url = fileName,
                Type = f.ContentType,
                Size = f.Length
            };
        }

        [HttpPost]
        public IActionResult Multiple(IFormFile[] af)
        {
            if (af != null && af.Length > 0)
            {
                string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                List<Upload> list = new List<Upload>();
                foreach (var item in af)
                    list.Add(DoUpload(item, root));

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

        [HttpPost]
        public IActionResult Ajax(IFormFile f)
        {
            if(f != null )
            {
                try
                {
                    string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                    Upload obj = DoUpload(f, root);
                    context.Uploads.Add(obj);

                    int ret = context.SaveChanges();
                    if (ret > 0)
                    {
                        TempData["Message"] = $"{ret} files uploaded successfully.";
                        return Json(obj);

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }    
            return Json(f.FileName);
        }

        [HttpPost]

        public IActionResult Folder(IFormFile[] af)
        {
            string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");

            List<Upload> list = new List<Upload>();

            foreach (var item in af)
            {
                if (item != null && item.Length > 0)
                {
                    string ext = Path.GetExtension(item.FileName);
                    string folder = Path.GetDirectoryName(item.FileName);

                    if (folder != null)
                    {
                        string fileName = Helper.RandomString(32 - ext.Length - folder.Length - 1);
                        string sub = Path.Combine(root, folder);
                        if (!Directory.Exists(sub))
                            Directory.CreateDirectory(sub);

                        using (Stream stream = new FileStream(Path.Combine(sub, fileName), FileMode.Create))
                        {
                            item.CopyTo(stream);
                        }

                        list.Add(new Upload()
                        {
                            OriginalName = item.FileName,
                            Url = Path.Combine(folder, fileName),
                            Type = item.ContentType,
                            Size = item.Length
                        });
                    }

                    Console.WriteLine(item.FileName);
                    //string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Folder");
                    //DoUpload(item, root);
                }
            }
            return View();
        }

        public IActionResult Folder()
        {
            return View();
        }
    }
}
