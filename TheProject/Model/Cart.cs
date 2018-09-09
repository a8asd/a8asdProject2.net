using System.Collections.Generic;

namespace TheProject.Model
{
    public class Cart
    {
        public IList<Book> Books { get; set; }

        public Cart()
        {
            Books = new List<Book>();
        }
    }
}
