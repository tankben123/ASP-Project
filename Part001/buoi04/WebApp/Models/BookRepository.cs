using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class BookRepository : BaseRepository
    {
        public BookRepository(StoreContext context) : base(context)
        {
        }

        public List<Book> GetBooks()
        {
            return context.Books.ToList();
        }
    }
}
