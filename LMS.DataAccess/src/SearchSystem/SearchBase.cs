using LMS.DataAccess.Core.Exceptions;
using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.SearchSystem;

public abstract class SearchBase < M, E, T >
{
    protected M Repository;
    private readonly ILogService _logService;

    public SearchBase(M manager)
    {
        Repository = manager;
        _logService = new LogService();
    }

    public virtual void PerformSearch(T criterion)
    {
        List<E> results = Search(criterion);
        
        try
        {
            if (results.Count > 0)
            {
                SearchResult(results);
            }
            else
            {
                NoResultsFound();
            }
        }
        catch (BookNotFoundException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch (PatronNotFoundException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An unexpected error occurred while searching.");
            _logService.LogError(Severity.HIGH, $"{ex.Message}");
        }
    }

    protected abstract List<E> Search(T criterion);

    protected virtual void SearchResult(List<E> results)
    {
        foreach (E item in results)
        {
            DisplayDetails(item);
        }
    }

    protected abstract void DisplayDetails(E item);

    protected abstract void NoResultsFound();
}
