using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StockController : Controller
    {
        StockRepository _repository;
        public StockController(StoreContext context)
        {
            _repository = new StockRepository(context);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Import()
        {
            List<Stock> list = new List<Stock>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "appl.csv");
            string[] lines = System.IO.File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 7) continue;
                Stock stock = new Stock
                {
                    Date = DateTime.Parse(parts[0]),
                    Open = double.Parse(parts[1]),
                    High = double.Parse(parts[2]),
                    Low = double.Parse(parts[3]),
                    Close = double.Parse(parts[4]),
                    AdjClose = double.Parse(parts[5]),
                    Volume = int.Parse(parts[6])
                };
                list.Add(stock);
            }
            int ret = _repository.ImportStocks(list);
            if (ret > 0)
            {
                return Redirect("/stock");
            }
            return Redirect("/stock/error");
        }

        public IActionResult Search(DateTime startDate, DateTime endDate)
        {
            if (startDate == default || endDate == default)
            {
                return Redirect("/stock");
            }
            List<Stock> stocks = _repository.GetStocks(startDate, endDate);
            return View(stocks);
        }
    }
}
