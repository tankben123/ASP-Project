using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BookController : Controller
    {
        BookRepository repository;
        public BookController(BookRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index(int id = 1)
        {
            int size = 500;
            int page;
            int total = repository.Count();
            if (total % size == 0)
                page = total / size;
            else
                page = total / size + 1;

            int slot = 5;
            int left = 1;
            int right = slot;
            int balance = slot / 2;
            int mid = balance + 1;

            if (id > mid)
            {
                right = id + balance;
                if (right > page)
                {
                    right = page;
                }    
                left = right - slot + 1;
            }    

            ViewBag.page = page;
            ViewBag.left = left; 
            ViewBag.right = right;

            return View(repository.GetBooks(id, size));
        }

        public IActionResult Search(string q)
        {
            int size = 500;
            return View(repository.SearchBook(q, size));
        }
    }

}
