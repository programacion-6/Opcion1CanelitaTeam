using LMS.DataAccess.Systems.Concretes.Managers;

namespace LMS.DataAccess.Services.Statistics.Abstracts;

public abstract class StatisticReport
{
    protected BorrowManager Borrows;

    public StatisticReport(BorrowManager borrows)
    {
        this.Borrows = borrows;
    }
    public abstract void Report();

}
