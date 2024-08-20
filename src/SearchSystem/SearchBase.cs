using System;
using System.Collections.Generic;

public abstract class SearchBase < M, E, T >
{
    protected M Repository;

    public SearchBase(M manager)
    {
        this.Repository = manager;
    }

    public virtual void PerformSearch(T criterion)
    {
        List<E> results = Search(criterion);
        
        if (results.Count > 0)
        {
            SearchResult(results);
        }
        
        else
        {
            NoResultsFound();
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

    protected virtual void NoResultsFound()
    {
        Console.WriteLine("No results found.");
    }
}
