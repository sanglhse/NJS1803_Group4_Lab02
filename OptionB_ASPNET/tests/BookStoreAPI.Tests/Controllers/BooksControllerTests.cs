using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreAPI.Controllers;
using BookStoreAPI.Models;
using BookStoreAPI.Interfaces;

namespace BookStoreAPI.Tests.Controllers
{
    [TestClass]
    public class BooksControllerTests
    {
        private Mock<IBookService> _mockBookService;
        private BooksController _booksController;

        [TestInitialize]
        public void Setup()
        {
            _mockBookService = new Mock<IBookService>();
            _booksController = new BooksController(_mockBookService.Object);
        }

        [TestMethod]
        public async Task GetAllBooks_ReturnsOkResult_WithListOfBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1", Genre = "Genre 1", Price = 9.99m },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2", Genre = "Genre 2", Price = 14.99m }
            };
            _mockBookService.Setup(service => service.GetAllBooks()).ReturnsAsync(books);

            // Act
            var result = await _booksController.GetAllBooks();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            var returnedBooks = okResult.Value as List<Book>;
            Assert.AreEqual(2, returnedBooks.Count);
        }

        [TestMethod]
        public async Task GetBookById_ReturnsNotFound_WhenBookDoesNotExist()
        {
            // Arrange
            int bookId = 1;
            _mockBookService.Setup(service => service.GetBookById(bookId)).ReturnsAsync((Book)null);

            // Act
            var result = await _booksController.GetBookById(bookId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task CreateBook_ReturnsCreatedAtActionResult_WithNewBook()
        {
            // Arrange
            var newBook = new Book { Title = "New Book", Author = "New Author", Genre = "New Genre", Price = 19.99m };
            _mockBookService.Setup(service => service.CreateBook(newBook)).ReturnsAsync(newBook);

            // Act
            var result = await _booksController.CreateBook(newBook);

            // Assert
            var createdResult = result as CreatedAtActionResult;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("GetBookById", createdResult.ActionName);
            Assert.AreEqual(newBook, createdResult.Value);
        }

        [TestMethod]
        public async Task UpdateBook_ReturnsNoContent_WhenBookIsUpdated()
        {
            // Arrange
            var updatedBook = new Book { Id = 1, Title = "Updated Book", Author = "Updated Author", Genre = "Updated Genre", Price = 29.99m };
            _mockBookService.Setup(service => service.UpdateBook(updatedBook)).ReturnsAsync(true);

            // Act
            var result = await _booksController.UpdateBook(updatedBook.Id, updatedBook);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteBook_ReturnsNotFound_WhenBookDoesNotExist()
        {
            // Arrange
            int bookId = 1;
            _mockBookService.Setup(service => service.DeleteBook(bookId)).ReturnsAsync(false);

            // Act
            var result = await _booksController.DeleteBook(bookId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}