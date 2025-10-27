using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
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

        public IActionResult Network(List<int> ids)
        {
            return View(ids);
        }

        [HttpPost("/employee/network")]
        public IActionResult LoadNetwork(List<int> ids)
        {
            IEnumerable<Employee> list = repository.GetEmployees(ids);
            IEnumerable<Employee> childen = repository.GetEmployeeByParent(ids);

            Dictionary<int, Node> dict = new Dictionary<int, Node>();
            foreach (Employee item in list)
            {
                dict[item.EmployeeId] = new Node
                {
                    Id = item.EmployeeId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Value = 15,
                    Gender = item.Gender ? "Male" : "Female",
                    Phone = item.Phone,
                    LinkWith = new List<int>()
                };
            }

            foreach (var item in childen)
            {
                Node node = new Node
                {
                    Id = item.EmployeeId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Value = 5,
                    Gender = item.Gender ? "Male" : "Female",
                    Phone = item.Phone
                };

                if (!dict.ContainsKey(node.Id))
                    dict[node.Id] = node;    

                if (item.ParentId != null)
                    dict[item.ParentId.Value].LinkWith.Add(node.Id);
            }
            return Json(dict.Values.ToList());
        }
    }
}
