namespace LMS.DataAccess.SearchSystem;

public class PerformSearch
{
    public static void Search <M,E,C> (SearchBase <M,E,C> search, C criteria)
    {
        search.PerformSearch(criteria);
    }
}