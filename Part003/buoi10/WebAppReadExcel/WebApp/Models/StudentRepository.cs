using MathNet.Numerics.Distributions;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;

namespace WebApp.Models
{
    public class StudentRepository : BaseRepository
    {
        public StudentRepository(StoreContext context) : base(context)
        {
        }


        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }


        public int Add(List<Student> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "Student cannot be null");
            }
            _context.Students.AddRange(list);
            return _context.SaveChanges();
        }

        public List<Student> GetStudents(int index, int size)
        {
            return _context.Students.Skip(index)
                .Take(size)
                .ToList();
        }


        public List<Student> GetStudents(int col, string dir, int index, int size, out int total)
        {
            string[] cols = {
                 "fullName",
                    "dateOfBirth",
                   "gender",
                   "identificationNumber",
                   "subject",
                    "'area",
                   "score1",
                   "score2",
                    "score3",
                   "srNo",
                   "majorId",
                    "scoreAreaExtra",
                   "scoreExtra",
            };
            var query = _context.Students;
            total = query.Count();

            string sql = $"SELECT * FROM Student ORDER BY {cols[col]} {(dir.Equals("asc") ? "ASC" : "DESC")} OFFSET {index} ROWS FETCH NEXT {size} ROWS ONLY";

            //if (dir.Equals("asc"))
            //{
            //    return query.OrderBy(c => cols[col]).Skip(index)
            //        .Take(size)
            //        .ToList();
            //}

            //return query.OrderByDescending(c => cols[col]).Skip(index)
            //    .Take(size)
            //    .ToList();

            return _context.Students.FromSqlRaw(sql).ToList();
        }


        public List<Student> Search(int col, string dir, string q, int index, int size, out int total)
        {
            string[] cols = {
                 "fullName",
                    "dateOfBirth",
                   "gender",
                   "identificationNumber",
                   "subject",
                    "'area",
                   "score1",
                   "score2",
                    "score3",
                   "srNo",
                   "majorId",
                    "scoreAreaExtra",
                   "scoreExtra",
            };
            var query = _context.Students
                .Where(s => s.FullName.Contains(q));

            total = query.Count();

            string sql = $"SELECT * FROM Student WHERE FullName LIKE '%{q}%' ORDER BY {cols[col]} {(dir.Equals("asc") ? "ASC" : "DESC")} OFFSET {index} ROWS FETCH NEXT {size} ROWS ONLY";
            return _context.Students.FromSqlRaw(sql).ToList();
            //if (dir.Equals("asc"))
            //{
            //    return query.OrderBy(c => cols[col]).Skip(index)
            //        .Take(size)
            //        .ToList();
            //}

            //return query.OrderByDescending(c => cols[col]).Skip(index)
            //    .Take(size)
            //    .ToList();
        }


        public List<Student> GetStudents(int index, int size, out int total)
        {
            string[] cols = {
                 "fullName",
                    "dateOfBirth",
                   "gender",
                   "identificationNumber",
                   "subject",
                    "'area",
                   "score1",
                   "score2",
                    "score3",
                   "srNo",
                   "majorId",
                    "scoreAreaExtra",
                   "scoreExtra",
            };
            var query = _context.Students;
            total = query.Count();

            //string sql = $"SELECT * FROM Student OFFSET {index} ROWS FETCH NEXT {size} ROWS ONLY";
            string sql = $"SELECT * FROM Student ORDER BY fullName ASC OFFSET {index} ROWS FETCH NEXT {size} ROWS ONLY";
            return _context.Students.FromSqlRaw(sql).ToList();
        }

        public Student? GetStudent(string? id)
        {
            return _context.Students.Where(p => p.IdentificationNumber == id).FirstOrDefault();
        }

        public int Edit(Student obj)
        {
            if (obj == null)
            {
                return -1;
            }

            Student? student = GetStudent(obj.IdentificationNumber);

            if (student == null)
            {
                return -1;
            }

            student.FullName = obj.FullName?.Trim();

            _context.Students.Update(student);
            return _context.SaveChanges();
        }

    }
}
