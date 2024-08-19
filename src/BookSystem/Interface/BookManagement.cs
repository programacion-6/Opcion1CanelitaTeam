using BookSystem;
public interface BookManagement{
        void AddBook(Book book);
        void UpdateBook(string title, string? newTitle = null, string? newAuthor = null, string? newGenre = null, DateTime? newPublicationDate = null);
        void RemoveBook(string title);
        void ListBooksByGenre(string genre);
        bool CheckAvailability(string title);
}