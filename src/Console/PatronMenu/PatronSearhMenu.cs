using BookSystem;
using LibraryConsole.Utils;

public class PatronSearchMenu{
    BookRepository Books;
    public PatronSearchMenu(BookRepository books){
        this.Books = books;
    }

    public void PatronSearchMenuOptions()
    {
        List<string> options = new List<string> { "Search by Title", "Search by Author", "Search by ISBN", "Exit" };

        while (true)
        {
            MenuGenerator.genericMenu("Books Search Menu", options);
            Console.Write("Please select an option: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= options.Count)
            {
                switch (selectedIndex)
                {
                    case 1:
                        SearchByTitle();
                        break;
                    case 2:
                        SearchByAuthor();
                        break;
                    case 3:
                        SearchByISBN();
                        break;
                    case 4:
                        Console.WriteLine("Exiting to main menu.");
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }


    public void SearchByTitle()
    {
        Console.Write("Enter the title of the book: ");
        string? title = Console.ReadLine();
        BookPerformSearch.BookSearchOption(new BookSearchByTitle(Books), title);

        
    }

    public void SearchByAuthor()
    {
        Console.Write("Enter the author of the book: ");
        string? author = Console.ReadLine();
        BookPerformSearch.BookSearchOption(new BookSearchByAuthor(Books), author);

    }

    public void SearchByISBN()
    {
        Console.Write("Enter the ISBN of the book: ");
        string? isbn = Console.ReadLine();
        BookPerformSearch.BookSearchOption(new BookSearchByISBN(Books), isbn);

    }


}