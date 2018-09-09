using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TheProject.Model;

namespace TheProject.Test.Steps
{
    [Binding]
    public class SearchBookSteps
    {
        private Library library = new Library();
        private List<StockItem> allBooks;
        private Cart cart = new Cart();

        private List<StockItem> MapToStockList(Table table)
        {
            return new List<StockItem>();
        }

        [Given(@"we have the following books in the stock:")]
        public void GivenWeHaveTheFollowingBooksInTheStock(Table table)
        {
            allBooks = MapToStockList(table);
        }
        
        [When(@"I request all books")]
        public void WhenIRequestAllBooks()
        {
            library.Stock.Items = allBooks;
        }
        
        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            var items = MapToStockList(table);
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i].Book.BookId, library.Stock.Items[i].Book.BookId);
            }
        }

        [Given(@"I have an empty cart")]
        public void GivenIHaveAnEmptyCart()
        {
            cart.Books.Clear();
        }

        [When(@"I want to add the book (.*) to my cart")]
        public void WhenIWnatToAddTheBookLordOfTheRingstoMyCart(string bookname)
        {
            cart.Books.Add(new Book(){Title = bookname});
        }

        [Then(@"My cart should not be empty anymore")]
        public void ThenMyCartShouldNotBeEmptyAnymore()
        {
            Assert.IsNotEmpty(cart.Books);
        }

    }
}
