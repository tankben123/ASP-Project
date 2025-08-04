using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Pkcs;
using WebAppDapper.Models;

namespace WebAppDapper.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository repository;
        public CategoryController(IConfiguration configuration)
        {
            repository = new CategoryRepository(configuration);
        }
        public async Task<IActionResult> Index()
        {
            return View(await repository.GetCategories());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                int ret = repository.Add(category);
                if (ret > 0)
                {
                    return Redirect("/category");
                }   
            }
            return View(category);
        }

        public IActionResult Delete(short categoryId)
        {
            if(repository.Delete(categoryId) > 0)
            {
                return Redirect("/category");
            }
            else
            {
                return NotFound();
            }
        }


        public IActionResult Edit(short categoryId)
        {
            var category = repository.GetCategory(categoryId);
            if (category != null)
            {
                return View(category);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                int ret = repository.Edit(category);
                if (ret > 0)
                {
                    return Redirect("/category");
                }
            }
            return View(category);
        }

    }
}
     