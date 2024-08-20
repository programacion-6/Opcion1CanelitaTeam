using System.Net.NetworkInformation;
using BorrowSystem;
using FinesSystem;
using LibraryConsole.Utils;
using ReportSystem.Concrete;
using StatisticSystem;

public class ReportStaffMenu
{
    BorrowManager Borrows;
    FineManager Fines;
    public ReportStaffMenu(BorrowManager Borrows, FineManager Fines)
    {
        this.Borrows = Borrows;
        this.Fines = Fines;
    }

    public void ReportMenu()
    {
        List<string> options = new List<string> { "Borrow Patron History", "Current Borrowed Books", "Overdue Books Report", "Statistics", "Fines List", "Exit" };

        while (true)
        {
            MenuGenerator.genericMenu("Report Staff Menu", options);
            Console.Write("Please select an option: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= options.Count)
            {
                switch (selectedIndex)
                {
                    case 1:
                        ShowBorrowPatronHistory();
                        break;
                    case 2:
                        ShowCurrentBorrowedBooks();
                        break;
                    case 3:
                        ShowOverDueBooksReport();
                        break;
                    case 4:
                        ShowStatistics();
                        break;
                    case 5:
                        ShowFines();
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

    private void ShowBorrowPatronHistory()
    {
        Console.Write("Enter Patron Name: ");
        string patronName = Console.ReadLine();
        BorrowPatronHistory history = new BorrowPatronHistory(Borrows);
        history.PatronBorrowHistoryReport(patronName);
    }

    private void ShowCurrentBorrowedBooks()
    {
        CurrrentBorrowBooksReport borrowedBooks = new CurrrentBorrowBooksReport(Borrows);
        borrowedBooks.BorrowedBooksReport();
    }

    private void ShowOverDueBooksReport()
    {
        OverdueBooksReport overdueBooks = new OverdueBooksReport(Borrows);
        overdueBooks.OverdueBooksListReport();
    }

    private void ShowStatistics()
    {
        Statistic statistics = new Statistic(new MostActivePatron(Borrows));
        statistics.makeStatistic();
        statistics = new Statistic(new MostBorrowedBook(Borrows));
        statistics.makeStatistic();
        
    }

    public void ShowFines(){
        Fines.ShowFines();
    }
}
