using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController:Controller
    {
        StudentRepository repository;
        public StudentController(StudentRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.GetStudents());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student obj) 
        {
            int ret = repository.Add(obj);
            if (ret > 0)
            {
                return Redirect("/student");
            }
            ModelState.AddModelError("Error", "insert student fail");
            return View(obj);
        }
    }
}
