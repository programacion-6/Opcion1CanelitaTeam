using LMS.DataAccess.Services.Statistics.Abstracts;

namespace LMS.DataAccess.Services.Statistics;

public class Statistic
{
    StatisticReport Report;
    public Statistic(StatisticReport report)
    {
        this.Report = report;
    }

    public void makeStatistic()
    {
        Report.Report();
    }
}
