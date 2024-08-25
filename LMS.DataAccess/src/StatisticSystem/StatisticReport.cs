using LMS.DataAccess.BorrowSystem;

namespace LMS.DataAccess.StatisticSystem;

public abstract class StatisticReport
{
    protected BorrowManager Borrows;

    public StatisticReport(BorrowManager borrows)
    {
        this.Borrows = borrows;
    }
    public abstract void Report();

}
