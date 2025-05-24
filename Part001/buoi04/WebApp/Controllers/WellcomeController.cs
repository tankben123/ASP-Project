using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class WellcomeController:Controller
    {
        public string Index()
        {
            return "Hello World";
        }


        public IActionResult Hi()
        {
            return View();
        }

        public IActionResult Example() 
        {
            Student student = new Student();
            student.Name = "thắng";
            Student studen2 = new Student("123") { Name = "Thien", Email = "abc@gmail.com" };

            return View(studen2);
        }
    }
}
