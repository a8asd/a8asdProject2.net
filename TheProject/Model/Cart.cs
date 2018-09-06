using System.Collections.Generic;

namespace TheProject.Model
{
    public class Cart
    {
        public IList<Book> Books { get; set; } = new List<Book>();
    }
}
