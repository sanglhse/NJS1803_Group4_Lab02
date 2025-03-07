namespace BookStoreAPI.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Book CreateBook(Book book);
        Book UpdateBook(int id, Book book);
        void DeleteBook(int id);
    }
}