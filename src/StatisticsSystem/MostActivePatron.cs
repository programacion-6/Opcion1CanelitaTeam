using BorrowSystem;

public class MostActivePatron : StatisticReport
{
    public MostActivePatron(BorrowManager borrows) : base(borrows)
    {
    }

    public override void Report()
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