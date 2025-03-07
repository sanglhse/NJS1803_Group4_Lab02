using Moq;
using BookStoreAPI.Interfaces;

namespace BookStoreAPI.Tests.Moq
{
    public class MockBookService
    {
        public Mock<IBookService> GetMockBookService()
        {
            var mockBookService = new Mock<IBookService>();

            // Setup mock methods as needed for tests
            // Example:
            // mockBookService.Setup(service => service.GetAllBooks()).ReturnsAsync(new List<Book> { /* test data */ });

            return mockBookService;
        }
    }
}