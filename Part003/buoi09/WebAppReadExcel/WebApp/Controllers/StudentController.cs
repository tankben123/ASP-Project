using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;
        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository), "Student repository cannot be null");
        }

        public IActionResult Index()
        {
            return View(_studentRepository.GetStudents());
        }

        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Import(IFormFile f)
        {
            List<Models.Student> list = new List<Student>();
            if (f == null || string.IsNullOrEmpty(f.FileName))
            {
                ModelState.AddModelError("File", "Please select a file to upload.");
                return View();
            }

            using (IWorkbook workbook = WorkbookFactory.Create(f.OpenReadStream()))
            {
                ISheet sheet = workbook.GetSheetAt(0);

                for (int i = 2; i < sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null)
                        continue;
                    try
                    {
                        var student = new Models.Student
                        {
                            FullName = row.GetCell(1).StringCellValue,
                            DateOfBirth = row.GetCell(2).StringCellValue,
                            Gender = row.GetCell(3).StringCellValue.Equals("Nữ") ? false : true,
                            IdentificationNumber = row.GetCell(4).StringCellValue,
                            Subject = row.GetCell(5).NumericCellValue.ToString(),
                            Area = row.GetCell(6).NumericCellValue.ToString(),
                            Score1 = ToDec(row.GetCell(7).NumericCellValue),
                            Score2 = ToDec(row.GetCell(8).NumericCellValue),
                            Score3 = ToDec(row.GetCell(9).NumericCellValue),
                            SrNo = Convert.ToInt32(row.GetCell(11).NumericCellValue),
                            MajorId = row.GetCell(12).StringCellValue,
                            ScoreAreaExtra = ToDec(row.GetCell(13).NumericCellValue),
                            ScoreExtra = ToDec(row.GetCell(14).NumericCellValue),
                        };
                        list.Add(student);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing row {i}: {ex.Message}");
                    }
                }

                int ret = _studentRepository.Add(list);
                if (ret > 0)
                {
                    return Redirect("/student");
                }
                else
                {
                    ModelState.AddModelError("", "Import failed. Please try again.");
                }
            }

            return View(list);
        }


        public static decimal ToDec(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToDecimal(value);
        }

        public IActionResult Show()
        {
            return View();
        }

        [HttpPost]
        public IActionResult List(int start, int length, IFormCollection form)
        {
            int total = _studentRepository.GetStudents().Count;

            int col = Convert.ToInt32(form["order[0][column]"]);
            string? dir = form["order[0][dir]"];
            dir = dir?.ToLower() == "asc" ? "asc" : "desc";

            string? q = form["search[value]"];
            List<Student> data;
            if(string.IsNullOrEmpty(q))
                data = _studentRepository.GetStudents(col, dir, start, length, out total);
            else
                data = _studentRepository.Search(col, dir, q, start, length, out total);

            var obj = new
            {
                Data = data,
                RecordsTotal = total,
                RecordsFiltered = total
            };
            return Json(obj);
        }


        [Route("/student/pagination/{page?}")]
        public IActionResult Pagination(int page = 1)
        {

            int size = 10;
            List<Student> students = _studentRepository.GetStudents((page - 1) * size, size, out int total);
            ViewBag.total = total;
            ViewBag.page = total / size + (total % size > 0 ? 1 : 0);
            return View(students);
        }

        [HttpGet("/student/edit/{page}/{identificationNumber}")]
        public IActionResult Edit(int page, string identificationNumber)
        {
            if (string.IsNullOrEmpty(identificationNumber))
            {
                return NotFound();
            }
            var student = _studentRepository.GetStudent(identificationNumber);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost("/student/edit/{page}/{identificationNumber}")]
        public IActionResult Edit(int page, string identificationNumber, Student obj)
        {
            if (string.IsNullOrEmpty(identificationNumber))
            {
                return NotFound();
            }
            if (obj == null)
            {
                return BadRequest();
            }
            obj.IdentificationNumber = identificationNumber;
            int ret = _studentRepository.Edit(obj);
            if (ret > 0)
            {
                TempData["Message"] = "Student updated successfully.";
                return Redirect($"/student/pagination/{page}");
            }
            return View(obj);
        }
    }
}
