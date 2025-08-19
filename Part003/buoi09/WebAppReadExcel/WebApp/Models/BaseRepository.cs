namespace WebApp.Models
{
    public abstract class BaseRepository
    {
       public StoreContext _context;
        public BaseRepository(StoreContext context)
        {
            _context = context;

        }
    }
}
