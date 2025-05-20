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

        public int Add(Student obj)
        {
            context.Students.Add(obj);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            Student? obj = GetStudent(id);
            if (obj != null)
            {
                context.Students.Remove(obj);
                return context.SaveChanges();
            }
            return -1;
        }

        public int Edit(Student obj)
        {
            context.Students.Update(obj);
            return context.SaveChanges();
        }

        public Student? GetStudent(int id)
        {
            return context.Students.Find(id);
        }
    }
}
