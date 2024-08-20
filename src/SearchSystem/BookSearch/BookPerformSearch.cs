using BookSystem;
using userSystem;
using userSystem.Concrete;

public class BookPerformSearch{

    public static void BookSearchOption <T>( BookSearchTemplate<T> search, T criteria)
    {
        search.PerformSearch(criteria);
    }
}
