namespace WebApp.Models
{
    public class StudentRepository
    {
        StoreContext context;
        public StudentRepository(StoreContext context)
        {
            this.context = context;
        }

        public List<Student> GetStudents()
        {
            return context.Students.ToList();
        }

        public int Add(Student obj) {
            context.Students.Add(obj);
            return context.SaveChanges();
        }
    }
}
