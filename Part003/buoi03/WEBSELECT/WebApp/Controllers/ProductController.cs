using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        OganiContext context;
        public ProductController(OganiContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Products.Include(p => p.SubCategory).ToList());
        }

        public IActionResult Add()
        {
            ViewBag.categories = context.Categories.Include(p => p.SubCategories).ToList();
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.categories = context.Categories.Include(p => p.SubCategories).ToList();
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Create()
        {
            Dictionary<int, SelectListGroup> dict = new Dictionary<int, SelectListGroup>();
            foreach (var item in context.Categories.ToList())
            {
                SelectListGroup group = new SelectListGroup() { Name = item.Name };
                dict.Add(item.Id, group);
            }

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in context.SubCategories.ToList())
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                    Group = dict[item.CategoryId]
                };
                items.Add(selectListItem);
            }

            ViewBag.categories = items;

            return View();
        }


        public IActionResult Update(int id)
        {
            Dictionary<int, SelectListGroup> dict = new Dictionary<int, SelectListGroup>();
            foreach (var item in context.Categories.ToList())
            {
                SelectListGroup group = new SelectListGroup() { Name = item.Name };
                dict.Add(item.Id, group);
            }

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in context.SubCategories.ToList())
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                    Group = dict[item.CategoryId]
                };
                items.Add(selectListItem);
            }

            ViewBag.categories = items;

            var product = context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Delete(int id) 
        {
            Product product = context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                context.Products.Remove(product);
                int ret = context.SaveChanges();
                if (ret > 0)
                {
                    return Redirect("/product");
                }
            }
            
            return Redirect("/product/error");
        }
    }
}
