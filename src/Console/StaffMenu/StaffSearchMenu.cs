using BookSystem;
using LibraryConsole.Utils;
using SearchSystem;
using userSystem;

public class StaffSearchMenu{
    BookRepository Books;
    PatronManager Patrons;
    public StaffSearchMenu(BookRepository books, PatronManager patrons){
        this.Books = books;
        this.Patrons = patrons;
    }

    public void PatronSearchMenuOptions()
    {
        List<string> options = new List<string> { "Search book by Title", "Search book by Author", "Search book by ISBN", "Search patron by Name", "Search patron by Membership Number", "Exit" };

        while (true)
        {
            MenuGenerator.genericMenu("Search Menu", options);
            Console.Write("Please select an option: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= options.Count)
            {
                switch (selectedIndex)
                {
                    case 1:
                        PatronSearchMenu searchTitle = new PatronSearchMenu(Books);
                        searchTitle.SearchByTitle();
                        break;
                    case 2:
                        PatronSearchMenu searchAuthor = new PatronSearchMenu(Books);
                        searchAuthor.SearchByAuthor();
                        break;
                    case 3:
                        PatronSearchMenu searchISBN = new PatronSearchMenu(Books);
                        searchISBN.SearchByISBN();
                        break;
                    case 4:
                        SearchPatronByName();
                        break;
                    case 5:
                        SearchPatronByMembershipNumber();
                        break;    
                    case 6:
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


    private void SearchPatronByName()
    {
        Console.Write("Enter the Name of the Patron: ");
        string? patronName = Console.ReadLine();
        if (!string.IsNullOrEmpty(patronName))
        {
            PerformSearch.Search(new PatronSearchByName(Patrons), patronName);    
        }
        else
        {
            Console.WriteLine("Title cannot be null or empty.");
        }
    }

    private void SearchPatronByMembershipNumber()
    {
        Console.Write("Enter the Membership Number of the Patron: ");
        string? input = Console.ReadLine();
        int patronMemberShip;
        if (int.TryParse(input, out patronMemberShip))
        {
            PerformSearch.Search(new PatronSearchByMembershipNumber(Patrons), patronMemberShip);
        }
        else
        {
            Console.WriteLine("Invalid membership number. Please enter a valid number.");
        }
    }
}
