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
            return Redirect(repository.Edit(obj));
        }

        public IActionResult Delete(int id) 
        {
           int ret = repository.Delete(id);
            if (ret > 0)
            {
                return Redirect("/student");
            }
            return View("/student/error");

        }

        public IActionResult Edit(int id)
        {
            return View(repository.GetStudent(id));
        }

        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            return Redirect(repository.Edit(obj));
        }

        public IActionResult Redirect(int ret)
        {
            if (ret >= 0)
            {
                return Redirect("/student");
            }
            ModelState.AddModelError("Error", "insert student fail");
            return Redirect("/student/error");
        }

        [HttpPost]
        public IActionResult DelAll(int[] ids)
        {
            if (repository.Delete(ids) >= 0) 
            {
                return Redirect("/student");
            }
            return View("/student/error");
        }

    }
}
