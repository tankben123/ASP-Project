using System;

namespace WebAppDapper.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public short CategoryId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? Unit { get; set; }
        public string? Description { get; set; }
        public string? Specification { get; set; }
        public string? ImageUrl { get; set; }
        public int UnitOfPrice { get; set; }
    }
}
