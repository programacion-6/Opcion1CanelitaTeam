namespace StatisticSystem;
public class Statistic{
    StatisticReport Report;
    public Statistic(StatisticReport report){
        this.Report = report;
    }

    public void makeStatistic(){
        Report.Report();
    }
}