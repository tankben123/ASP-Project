using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MajorController : Controller
    {
        MajorRepository MajorRepository;
        public MajorController(MajorRepository majorRepository)
        {
            MajorRepository = majorRepository ?? throw new ArgumentNullException(nameof(majorRepository), "Major repository cannot be null");
        }

        public IActionResult Index()
        {
            return View(MajorRepository.GetMajors());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Major obj)
        {
            if (ModelState.IsValid)
            {
                int ret = MajorRepository.Add(obj);
                if (ret > 0)
                {
                    TempData["Message"] = "Major added successfully!";
                    return Redirect("/major");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to add major. Please try again.");
                }
            }
            return View(obj);
        }

    }
}
