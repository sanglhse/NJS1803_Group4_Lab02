using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books;

        public BookService()
        {
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "1984", Author = "George Orwell", Genre = "Dystopian", Price = 9.99m },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", Price = 7.99m }
            };
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void CreateBook(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = GetBookById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Genre = book.Genre;
                existingBook.Price = book.Price;
            }
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}