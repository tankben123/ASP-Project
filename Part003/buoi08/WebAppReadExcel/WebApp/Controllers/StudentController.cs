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
    }
}
