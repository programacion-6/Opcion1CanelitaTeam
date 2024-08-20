using BorrowSystem;

public class MostBorrowedBook : StatisticReport
{
    public MostBorrowedBook(BorrowManager borrows) : base(borrows)
    {
    }

    public override void Report()
    {
        var borrowList = Borrows.GetBorrows();

        var mostBorrowedBook = borrowList
            .GroupBy(b => b.GetBook().Title)
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
}