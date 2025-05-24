using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class BookRepository : BaseRepository
    {
        public BookRepository(StoreContext context) : base(context)
        {
        }

        public List<Book> GetBooks(int page, int size)
        {
            return context.Books.Skip((page - 1) * size).Take(size).ToList();
        }

        public int Count()
        {
            return context.Books.Count();
        }

        public List<Book> SearchBook(string q, int size)
        {
            return context.Books.Take(size).Where(x => x.Title.Contains(q)).ToList();
        }
    }
}
