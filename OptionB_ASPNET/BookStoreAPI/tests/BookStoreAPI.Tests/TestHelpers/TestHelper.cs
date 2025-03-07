using System.Collections.Generic;
using BookStoreAPI.Models;

namespace BookStoreAPI.Tests.TestHelpers
{
    public static class TestHelper
    {
        public static List<Book> GetTestBooks()
        {
            return new List<Book>
            {
                new Book { Id = 1, Title = "Test Book 1", Author = "Author 1", Genre = "Fiction", Price = 9.99m },
                new Book { Id = 2, Title = "Test Book 2", Author = "Author 2", Genre = "Non-Fiction", Price = 14.99m },
                new Book { Id = 3, Title = "Test Book 3", Author = "Author 3", Genre = "Science Fiction", Price = 19.99m }
            };
        }

        public static Book GetTestBook()
        {
            return new Book { Id = 1, Title = "Test Book", Author = "Test Author", Genre = "Test Genre", Price = 10.00m };
        }
    }
}