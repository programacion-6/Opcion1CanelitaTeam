namespace BookSystem;
public class Book{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public string ISBN { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Stock { get; set; }

    public Book(string title, string author, string genre, DateTime publicationDate, string isbn )
    {
        Title = title;
        Author = author;
        Genre = genre;
        PublicationDate = publicationDate;
        ISBN = isbn;
    }

    public void BookDetails()
    {
        Console.WriteLine("========== Book Information ==========");
        Console.WriteLine($"Title:              {Title}");
        Console.WriteLine($"Author:             {Author}");
        Console.WriteLine($"Genre:              {Genre}");
        Console.WriteLine($"ISBN:               {ISBN}");
        Console.WriteLine($"Publication Date:   {PublicationDate.ToShortDateString()}");
        Console.WriteLine($"Stock:              {Stock}");
        Console.WriteLine("======================================");
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