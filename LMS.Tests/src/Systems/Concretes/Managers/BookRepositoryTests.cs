using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Systems.Concretes.Managers;

public class BookManagerTests
{
    [Fact]
    public void Add_ValidBook_ReturnsTrue()
    {
        var bookManager = new BookManager();
        var book = new Book("Title", "Author", "Genre", DateTime.Now.AddDays(-2), "1234567890") { Stock = 5 };

        bool result = bookManager.Add(book);

        Assert.True(result);
        Assert.Contains(book, bookManager.GetAll());
    }

    [Fact]
    public void Add_InvalidBook_ReturnsFalse()
    {
        var bookManager = new BookManager();
        var book = new Book("", "Author", "Genre", DateTime.Now, "12345");

        bool result = bookManager.Add(book);

        Assert.False(result);
        Assert.DoesNotContain(book, bookManager.GetAll());
    }

    [Fact]
    public void Remove_InvalidBook_ReturnsFalse()
    {
        var bookManager = new BookManager();
        var book = new Book("Title", "Author", "Genre", DateTime.Now, "12345");

        bool result = bookManager.Remove(book);

        Assert.False(result);
    }

    [Fact]
    public void CheckAvailability_BookInStock_ReturnsTrue()
    {
        var bookManager = new BookManager();
        var book = new Book("Title", "Author", "Genre", DateTime.Now, "1234567890") { Stock = 6 };
        book.Stock = 5;
        bookManager.Add(book);

        bool result = bookManager.CheckAvailability("Title");

        Assert.True(result);
    }

    [Fact]
    public void CheckAvailability_BookOutOfStock_ReturnsFalse()
    {
        var bookManager = new BookManager();
        var book = new Book("Title", "Author", "Genre", DateTime.Now, "1234567890");
        book.Stock = 0;
        bookManager.Add(book);

        bool result = bookManager.CheckAvailability("Title");

        Assert.False(result);
    }

}
