namespace WebApp.Models
{
    public class Student
    {
        //string name;
        //public string Name 
        //{ 
        //    get 
        //    { 
        //        return name; 
        //    } 
        //    set 
        //    { name = value; 
        //    } 
        //}
        public string Name { get; set; }
        public string Email {  private get; set; }
        public string Password { get; private set; }

        public Student()
        { 
        }

        public Student(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public Student(string password)
        {
            Password = password;
        }
    }
}
