using System.Collections.Generic;

namespace TheProject.Model
{
    public class Library
    {
        public Library()
        {
            Members = new List<Member>();
            Stock = new Stock();
        }

        public Stock Stock { get; set; }

        public List<Member> Members { get; set; }
    }
}