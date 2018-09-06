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

        private List<StockItem> MapToStockList(Table table)
        {
            return (from item in table.CreateSet<(string Id, string Title, string ISBN, string Status)>().ToList()
                select
                new StockItem
                {
                    Book = new Book
                    {
                        BookId = item.Id,
                        ISBN = item.ISBN,
                        Title = item.Title
                    },
                    Status = item.Status
                }).ToList();
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
    }
}
