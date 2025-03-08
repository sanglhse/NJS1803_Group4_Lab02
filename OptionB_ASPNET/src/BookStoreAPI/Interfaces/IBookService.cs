using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Task<Book> CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}