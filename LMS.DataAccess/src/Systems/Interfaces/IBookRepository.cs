using LMS.DataAccess.Systems.Entities;

namespace LMS.DataAccess.Systems.Interfaces;

public interface IBookRepository
{
    void AddBook(Book book);
    void UpdateBook(string isbn, Book book);
    void RemoveBook(string isbn);
    List<Book> GetAllBooks();
}
