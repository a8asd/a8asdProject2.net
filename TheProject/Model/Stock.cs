using System.Collections.Generic;

namespace TheProject.Model
{
    public class Stock
    {
        public List<StockItem> Items { get; set; }

        public Stock()
        {
            Items = new List<StockItem>();
        }
    }
}