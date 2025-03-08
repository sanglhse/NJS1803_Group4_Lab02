using System;
using Xunit;

namespace BookStoreAPI.Tests.Models
{
    public class BookTests
    {
        [Fact]
        public void Book_Properties_Should_Set_And_Get_Values()
        {
            // Arrange
            var book = new Book
            {
                Id = 1,
                Title = "Test Book",
                Author = "Test Author",
                Genre = "Fiction",
                Price = 19.99m
            };

            // Act & Assert
            Assert.Equal(1, book.Id);
            Assert.Equal("Test Book", book.Title);
            Assert.Equal("Test Author", book.Author);
            Assert.Equal("Fiction", book.Genre);
            Assert.Equal(19.99m, book.Price);
        }
    }
}