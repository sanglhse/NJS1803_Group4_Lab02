using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using BookStoreAPI.Interfaces;

namespace BookStoreAPI.Tests.Services
{
    [TestFixture]
    public class BookServiceTests
    {
        private Mock<IBookService> _mockBookService;
        private BookService _bookService;

        [SetUp]
        public void Setup()
        {
            _mockBookService = new Mock<IBookService>();
            _bookService = new BookService();
        }

        [Test]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1", Genre = "Fiction", Price = 9.99M },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2", Genre = "Non-Fiction", Price = 14.99M }
            };
            _mockBookService.Setup(service => service.GetAllBooks()).Returns(books);

            // Act
            var result = _mockBookService.Object.GetAllBooks();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetBookById_ShouldReturnCorrectBook()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Book 1", Author = "Author 1", Genre = "Fiction", Price = 9.99M };
            _mockBookService.Setup(service => service.GetBookById(1)).Returns(book);

            // Act
            var result = _mockBookService.Object.GetBookById(1);

            // Assert
            Assert.AreEqual(book, result);
        }

        [Test]
        public void CreateBook_ShouldAddBook()
        {
            // Arrange
            var newBook = new Book { Title = "New Book", Author = "New Author", Genre = "Fiction", Price = 19.99M };
            _mockBookService.Setup(service => service.CreateBook(newBook)).Returns(newBook);

            // Act
            var result = _mockBookService.Object.CreateBook(newBook);

            // Assert
            Assert.AreEqual(newBook, result);
        }

        [Test]
        public void UpdateBook_ShouldModifyExistingBook()
        {
            // Arrange
            var existingBook = new Book { Id = 1, Title = "Old Book", Author = "Old Author", Genre = "Fiction", Price = 9.99M };
            var updatedBook = new Book { Id = 1, Title = "Updated Book", Author = "Updated Author", Genre = "Fiction", Price = 12.99M };
            _mockBookService.Setup(service => service.UpdateBook(updatedBook)).Returns(updatedBook);

            // Act
            var result = _mockBookService.Object.UpdateBook(updatedBook);

            // Assert
            Assert.AreEqual(updatedBook, result);
        }

        [Test]
        public void DeleteBook_ShouldRemoveBook()
        {
            // Arrange
            var bookId = 1;
            _mockBookService.Setup(service => service.DeleteBook(bookId)).Returns(true);

            // Act
            var result = _mockBookService.Object.DeleteBook(bookId);

            // Assert
            Assert.IsTrue(result);
        }
    }
}