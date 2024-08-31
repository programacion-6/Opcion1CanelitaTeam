using LMS.DataAccess.Systems.Entities;

public class BookTests
{
    [Fact]
    public void Book_Creation_Test()
    {
        var book = new Book("C# Programming", "John Doe", "Programming", new DateTime(2020, 5, 1), "1234567890");

        Assert.Equal("C# Programming", book.Title);
        Assert.Equal("John Doe", book.Author);
        Assert.Equal("Programming", book.Genre);
        Assert.Equal("1234567890", book.ISBN);
        Assert.Equal(new DateTime(2020, 5, 1), book.PublicationDate);
    }

    [Fact]
    public void Set_Title_Test()
    {
        var book = new Book("C# Programming", "John Doe", "Programming", new DateTime(2020, 5, 1), "1234567890");
        book.Title = "Advanced C#";

        Assert.Equal("Advanced C#", book.Title);
    }

    [Fact]
    public void Set_Author_Test()
    {
        var book = new Book("C# Programming", "John Doe", "Programming", new DateTime(2020, 5, 1), "1234567890");
        book.Author = "Jane Doe";

        Assert.Equal("Jane Doe", book.Author);
    }

    [Fact]
    public void Set_Genre_Test()
    {
        var book = new Book("C# Programming", "John Doe", "Programming", new DateTime(2020, 5, 1), "1234567890");
        book.Genre = "Software Development";

        Assert.Equal("Software Development", book.Genre);
    }

    [Fact]
    public void Set_ISBN_Test()
    {
        var book = new Book("C# Programming", "John Doe", "Programming", new DateTime(2020, 5, 1), "1234567890");
        book.ISBN = "0987654321";

        Assert.Equal("0987654321", book.ISBN);
    }

    [Fact]
    public void Set_PublicationDate_Test()
    {
        var book = new Book("C# Programming", "John Doe", "Programming", new DateTime(2020, 5, 1), "1234567890");
        book.PublicationDate = new DateTime(2021, 8, 15);

        Assert.Equal(new DateTime(2021, 8, 15), book.PublicationDate);
    }

    [Fact]
    public void Set_Stock_Test()
    {
        var book = new Book("C# Programming", "John Doe", "Programming", new DateTime(2020, 5, 1), "1234567890");
        book.Stock = 10;

        Assert.Equal(10, book.Stock);
    }

    [Fact]
    public void IncreaseStock_Test()
    {
        var book = new Book("C# Programming", "John Doe", "Programming", new DateTime(2020, 5, 1), "1234567890");
        book.Stock = 5;
        book.IncreaseStock();

        Assert.Equal(6, book.Stock);
    }

    [Fact]
    public void DecreaseStock_WhenStockAvailable_Test()
    {
        var book = new Book("C# Programming", "John Doe", "Programming", new DateTime(2020, 5, 1), "1234567890");
        book.Stock = 5;
        book.DecreaseStock();

        Assert.Equal(4, book.Stock);
    }

    [Fact]
    public void DecreaseStock_WhenStockIsZero_Test()
    {
        var book = new Book("C# Programming", "John Doe", "Programming", new DateTime(2020, 5, 1), "1234567890");
        book.Stock = 0;
        book.DecreaseStock();

        Assert.Equal(0, book.Stock);
    }
   
}
