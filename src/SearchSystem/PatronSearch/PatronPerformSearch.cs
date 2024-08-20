using userSystem;
using userSystem.Concrete;

namespace SearchSystem;
public class PatronPerformSearch{

    public static void PatronSearchOption <T>( PatronSearchTemplate<T> search, T criteria)
    {
        search.PerformSearch(criteria);
    }
}
