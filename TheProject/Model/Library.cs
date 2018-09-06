using System.Collections.Generic;

namespace TheProject.Model
{
    public class Library
    {
        public Stock Stock { get; set; } = new Stock();

        public List<Member> Members { get; set; } = new List<Member>();
    }
}