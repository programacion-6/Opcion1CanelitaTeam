using BookSystem;
using BorrowSystem;
using FinesSystem;
using LibraryConsole.Utils;
using userSystem;
using userSystem.Concrete;

namespace LibraryConsole.PatronMenuOtions;
public class StaffMenu{

    Staff Staff;
    BorrowManager Borrows;
    BookManager Books;
    PatronManager Patrons;
    FineManager Fines;

    public StaffMenu(Staff staff, BorrowManager borrows, BookManager books, PatronManager patrons, FineManager Fines){
        this.Staff = staff;
        this.Borrows = borrows;
        this.Books = books;
        this.Patrons = patrons;
        this.Fines= Fines;
    }

    public void ShowStaffMenu()
    {
        List<string> options = new List<string> { "User details", "Book Management","Report Management", "Search Tool", "Books List", "Exit" };

        while (true)
            {
                MenuGenerator.genericMenu($"Welcome {Staff.getName()}", options);
                Console.Write("Please select an option: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= options.Count)
                {
                    switch (selectedIndex)
                    {
                        case 1:
                            Staff.UserInformation();
                            break;
                        case 2:
                            BookStaffManagement BookManagement = new BookStaffManagement(Books);
                            BookManagement.BookStaffMenu();
                            break;
                        case 3:
                            ReportStaffMenu ReportMenu = new ReportStaffMenu(Borrows, Fines);
                            ReportMenu.ReportMenu();
                            break;
                        case 4:
                            StaffSearchMenu SearchMenu = new StaffSearchMenu(Books, Patrons);
                            SearchMenu.PatronSearchMenuOptions();
                            break;
                        case 5:
                            Books.AvailableBooks();
                            break;    
                        case 6:
                            Console.WriteLine("Exiting the system. Goodbye!");
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
}