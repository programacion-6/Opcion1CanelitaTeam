namespace LMS.DataAccess.BookSystem.Entities;

public class Book
{
    private string _title;
    private string _author;
    private string _genre;
    private string _isbn;
    private DateTime _publicationDate;
    private int _stock;

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public string Author
    {
        get { return _author; }
        set { _author = value; }
    }

    public string Genre
    {
        get { return _genre; }
        set { _genre = value; }
    }

    public string ISBN
    {
        get { return _isbn; }
        set { _isbn = value; }
    }

    public DateTime PublicationDate
    {
        get { return _publicationDate; }
        set { _publicationDate = value; }
    }

    public int Stock
    {
        get { return _stock; }
        set { _stock = value; }
    }

    public Book(string title, string author, string genre, DateTime publicationDate, string isbn)
    {
        _title = title;
        _author = author;
        _genre = genre;
        _publicationDate = publicationDate;
        _isbn = isbn;
    }

    public void BookDetails()
    {
        System.Console.WriteLine("========== Book Information ==========");
        System.Console.WriteLine($"Title:              {Title}");
        System.Console.WriteLine($"Author:             {Author}");
        System.Console.WriteLine($"Genre:              {Genre}");
        System.Console.WriteLine($"ISBN:               {ISBN}");
        System.Console.WriteLine($"Publication Date:   {PublicationDate.ToShortDateString()}");
        System.Console.WriteLine($"Stock:              {Stock}");
        System.Console.WriteLine("======================================");
    }

    public void IncreaseStock()
    {
        Stock++;
    }

    public void DecreaseStock()
    {
        if (Stock > 0)
        {
            Stock--;
        }
    }

    internal void setStock(int v)
    {
        Stock = v;
    }
}
