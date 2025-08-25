using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tls;
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

        public IActionResult Search(string term)
        {
            return Json(MajorRepository.Search(term).Select(p => new { Id = p.MajorId, Value = p.MajorName }));
        }

        public IActionResult Student()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Find(string term)
        {
            
            return Json(MajorRepository.Search(term).Select(p => new { Id = p.MajorId, Value = p.MajorName }));
        }

        [HttpPost]
        public IActionResult GetStudents(string id)
        {
            return Json(MajorRepository.GetStudentByMajor(id));
        }

        public IActionResult Show()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PartialShow([FromForm] string q)
        {
            //partial view khác view ở chỗ nó không có layout
            return PartialView(MajorRepository.GetStudentByMajor(q));
        }
    }
}
