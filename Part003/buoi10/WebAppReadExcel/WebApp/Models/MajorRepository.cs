namespace WebApp.Models
{
    public class MajorRepository:BaseRepository
    {
        public MajorRepository(StoreContext context) : base(context)
        {
        }
        public List<Major> GetMajors()
        {
            return _context.Majors.ToList();
        }
        public int Add(Major obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Major cannot be null");
            }

            if (string.IsNullOrWhiteSpace(obj.MajorId))
            {
                // Generate a unique ID if MajorId is null or empty
                obj.MajorId = Guid.NewGuid().ToString();
            }

            if (string.IsNullOrWhiteSpace(obj.MajorName))
            {
                throw new ArgumentException("Major name cannot be null or empty", nameof(obj.MajorName));
            }

            _context.Majors.Add(obj);
            return _context.SaveChanges();
        }
        public List<Major> GetMajors(int index, int size)
        {
            return _context.Majors.Skip(index)
                .Take(size)
                .ToList();
        }
    }
}
