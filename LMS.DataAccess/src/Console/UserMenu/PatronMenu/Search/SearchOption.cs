using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search;

public class SearchOption {
    SearchInput? _search;
    public void SetSearchOption(SearchInput _search){
        this._search = _search;
    }

    public void Execute(){
        if(_search != null){
            _search.SearchByInput();
        }
    }   
}