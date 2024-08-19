namespace BookSystem;
public class Book{
    string Title;
    string Author;
    string Genre;
    string ISBN;
    DateTime PublicationDate;  
    int Stock;

    public Book(string Title, string Author, string Genre, DateTime PublicationDate, string ISBN){
        this.Title = Title;
        this.Author = Author;
        this.Genre = Genre;
        this.PublicationDate = PublicationDate;
        this.ISBN = ISBN;
    }
    public string getTitle() => Title;
    public string getAuthor() => Author;
    public string getGenre() => Genre;
    public DateTime getPublicationDate() => PublicationDate;
    public int getStock() => Stock;
    public string getISBN() => ISBN;

    public void setTitle(string title) => this.Title = title;
    public void setAuthor(string author) => this.Author = author;
    public void setGenre(string genre) => this.Genre = genre;
    public void setPublicationDate(DateTime publicationDate) => this.PublicationDate = publicationDate;
    public void setStock(int stock) => this.Stock = stock;
    public void getISBN(string isbn) => this.ISBN = isbn;

    public void BookDetails(){
        Console.WriteLine("========== Book Information ==========");
        Console.WriteLine($"Title:              {Title}");
        Console.WriteLine($"Author:             {Author}");
        Console.WriteLine($"Genre:              {Genre}");
        Console.WriteLine($"ISBN:               {ISBN}");
        Console.WriteLine($"Publication Date:   {PublicationDate.ToShortDateString()}");
        Console.WriteLine($"Stock:              {Stock}");
        Console.WriteLine("======================================");
    }

    public void increaseStock(){
        this.Stock = Stock + 1;
    }

    public void decreaseStock(){
        this.Stock = Stock - 1;
    }
}