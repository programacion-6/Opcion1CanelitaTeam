public class ListAction{
    ListPagination? _page;
    public void setPagination(ListPagination _page)
    {
        this._page = _page;
    }

    public void Execute(){
        if(_page!=null){
            _page.DisplayList();
        }else{
            throw new InvalidCastException();
        }
    }

}