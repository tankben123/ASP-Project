using Microsoft.AspNetCore.Mvc;
using WebAppDapper.Models;

namespace WebAppDapper.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductController(IConfiguration configuration)
        {
            _productRepository = new ProductRepository(configuration);
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();
            return View(products);
        }

        public IActionResult Search(string q)
        {
            if (!string.IsNullOrEmpty(q))
            {
                return View(_productRepository.SearchProducts(q.Trim()));
            }

            return Redirect("/product");
        }
    }
}
