using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SelectController : Controller
    {

        OganiContext context;
        public SelectController(OganiContext context)
        {
            this.context = context;
        }

        public IActionResult TagHelper()
        {
            ViewBag.categories = new SelectList(context.Categories.ToList(), "Id", "Name");
            return View();
        }

        public IActionResult Simple()
        {
            ViewBag.categories = context.Categories.ToList();
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Simple(SubCategory obj)
        {
            context.SubCategories.Add(obj);
            int ret = context.SaveChanges();
            if (ret > 0)
            {
                return Redirect("/select/subcategory");
            }
            return View();
        }

        public IActionResult SubCategory()
        {
            return View(context.SubCategories.Include(p => p.Category).ToList());
        }

        public IActionResult EditSubCategory(int id)
        {
            ViewBag.categories = context.Categories.ToList();

            var subCategory = context.SubCategories.FirstOrDefault(x => x.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }
            return View(subCategory);
        }

        public IActionResult EditSubCategory2(int id)
        {
            ViewBag.categories = context.Categories.ToList();

            var subCategory = context.SubCategories.FirstOrDefault(x => x.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }
            return View(subCategory);
        }

        [HttpPost] 
        public IActionResult EditSubCategory(SubCategory subCategory, int id)
        {
            if (ModelState.IsValid)
            {
                context.SubCategories.Update(subCategory);
                int ret = context.SaveChanges();
                return Redirect("/select/SubCategory");
            }


            return View(subCategory);
        }
    }
}
