using Moq;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Models;

namespace BookStoreAPI.Tests.Moq
{
    public class MockBookService
    {
        public Mock<IBookService> GetMockBookService()
        {
            var mockBookService = new Mock<IBookService>();
            return mockBookService;
        }
    }
}