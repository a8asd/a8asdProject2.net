using System.Collections.Generic;

namespace TheProject.Model
{
    public class Stock
    {
        public List<StockItem> Items { get; set; } = new List<StockItem>();
    }
}