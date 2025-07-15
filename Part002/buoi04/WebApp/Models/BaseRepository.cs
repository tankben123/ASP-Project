namespace WebApp.Models
{
    public abstract class BaseRepository
    {
        protected StoreContext context;
        protected BaseRepository(StoreContext context) { 
        this.context = context;
        }
    }
}
