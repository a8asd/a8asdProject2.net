using System;
using TheProject.Model;

namespace TheProject.Controller
{
    public class CheckoutProcessor
    {
        public string Output { get; set; }

        public void Checkout(Cart cart)
        {
            if (cart.Books.Count < 1)
            {
                Output = "No books in cart";
                return;
            }

            Output = "Book(s) will be delivered";
        }
    }
}