using BorrowSystem;

namespace StatisticsSystem;
public class Statistics
{
    BorrowManager Borrows;
    public Statistics(BorrowManager Borrows)
    {
        this.Borrows = Borrows;
    }

    public void MostBorrowedBook()
        {
            var borrowList = Borrows.GetBorrows();

            var mostBorrowedBook = borrowList
                .GroupBy(b => b.GetBook().getTitle())
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            if (mostBorrowedBook != null)
            {
                Console.WriteLine($"Most Borrowed Book: {mostBorrowedBook.Key} - {mostBorrowedBook.Count()} times");
            }
            else
            {
                Console.WriteLine("No books have been borrowed yet.");
            }
        }

 
    public void MostActivePatron()
    {
        var borrowList = Borrows.GetBorrows();

        var mostActivePatron = borrowList
            .GroupBy(b => b.GetPatron().getName())
            .OrderByDescending(g => g.Count())
            .FirstOrDefault();

        if (mostActivePatron != null)
        {
            Console.WriteLine($"Most Active Patron: {mostActivePatron.Key} - {mostActivePatron.Count()} borrows");
        }
        else
        {
            Console.WriteLine("No patrons have borrowed books yet.");
        }
        }
}