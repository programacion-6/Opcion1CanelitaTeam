using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Systems.Concretes.Managers;

public class BookRepositoryTests
{
    private readonly BookRepository _repository;

    public BookRepositoryTests()
    {
        _repository = new BookRepository();
    }

    [Fact]
    public void AddBook_ValidBook_AddsBookToList()
    {
        var book = new Book("1984", "George Orwell", "Dystopian", new DateTime(1949, 6, 8), "1234567890") { Stock = 5};
        _repository.AddBook(book);

        var allBooks = _repository.GetAllBooks();
        Assert.Contains(book, allBooks);
    }

    [Fact]
    public void UpdateBook_ValidUpdate_UpdatesBookDetails()
    {
        var originalBook = new Book("Original Title", "Original Author", "Fiction", new DateTime(2000, 1, 1), "1234567890")  { Stock = 5};
        _repository.AddBook(originalBook) ;
        var updatedBook = new Book("Updated Title", "Updated Author", "Fiction", new DateTime(1999, 1, 1), "1234567890")  { Stock = 5};

        _repository.UpdateBook("1234567890", updatedBook);

        var allBooks = _repository.GetAllBooks();
        var book = allBooks.Find(b => b.ISBN == "1234567890");
        if (book != null)
        {
            Assert.Equal("Updated Title", book.Title);
            Assert.Equal("Updated Author", book.Author);
            Assert.Equal("Fiction", book.Genre);
            Assert.Equal(new DateTime(1999, 1, 1), book.PublicationDate);
        }
    }


    [Fact]
    public void RemoveBook_ValidISBN_RemovesBookFromList()
    {
        var book = new Book("To Be Removed", "Author", "Genre", new DateTime(2000, 1, 1), "9876543210")  { Stock = 5};
        _repository.AddBook(book);

        _repository.RemoveBook("9876543210");

        var allBooks = _repository.GetAllBooks();
        Assert.DoesNotContain(book, allBooks);
    }

    [Fact]
    public void CheckAvailability_BookOutOfStock_ReturnsFalse()
    {
        var book = new Book("Unavailable Book", "Author", "Genre", new DateTime(2000, 1, 1), "555") { Stock = 0};
        _repository.AddBook(book);

        var isAvailable = _repository.CheckAvailability("Unavailable Book");

        Assert.False(isAvailable);
    }
}
