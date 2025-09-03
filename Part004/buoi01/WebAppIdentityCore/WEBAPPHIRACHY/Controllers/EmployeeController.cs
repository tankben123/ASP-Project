using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository repository;
        public EmployeeController(IConfiguration configuration)
        {
            repository = new EmployeeRepository(configuration);
        }
        public IActionResult Index()
        {
            var employees = repository.GetEmployees();
            return View(employees);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee obj)
        {
            if (ModelState.IsValid)
            {
                int ret = repository.AddWithProcedure(obj);
                if (ret > 0)
                {
                    return Redirect("/employee");
                }
            }
            return View();
        }
    }
}
