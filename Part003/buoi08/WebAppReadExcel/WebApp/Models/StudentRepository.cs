namespace WebApp.Models
{
    public class StudentRepository: BaseRepository
    {
        public StudentRepository(StoreContext context): base(context)
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
    }
}
