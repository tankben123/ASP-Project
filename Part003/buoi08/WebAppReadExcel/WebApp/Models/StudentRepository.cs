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

        public List<Student> Search(string q, int index, int size, out int total)
        {
            var query = _context.Students
                .Where(s => s.FullName.Contains(q));

            total = query.Count();

            return query.Skip(index)
                .Take(size)
                .ToList();
        }

    }
}
