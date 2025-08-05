namespace WebApp.Models
{
    public class StockRepository:BaseRepository
    {
        public StockRepository(StoreContext context) : base(context)
        {
        }
        public List<Stock> GetStocks()
        {
            return _context.Stocks.ToList();
        }
        public int AddStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            return _context.SaveChanges();
        }
        public int ImportStocks(List<Stock> stocks)
        {
            _context.Stocks.AddRange(stocks);
            return _context.SaveChanges();
        }
    }
}
