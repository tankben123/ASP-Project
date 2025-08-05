namespace WebApp.Models
{
    public abstract class BaseRepository
    {
        protected readonly StoreContext _context;

        public BaseRepository(StoreContext context)
        {
            _context = context;
        }
    }
}
