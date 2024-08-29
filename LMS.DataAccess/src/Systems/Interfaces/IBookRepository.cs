using LMS.DataAccess.Systems.Entities;

namespace LMS.DataAccess.Systems.Interfaces;

public interface IBookRepository
{
    void AddBook(Book book);
    void UpdateBook(string title, string? newTitle = null, string? newAuthor = null, string? newGenre = null, DateTime? newPublicationDate = null, int? newStock = null);
    void RemoveBook(string title);
    void ListBooksByGenre(string genre);
    bool CheckAvailability(string title);
}
