namespace FinesSystem;
public class FineManager{
    List<Fine> Fines;
    public FineManager(){
        Fines = new List<Fine>();
    }

    public void AddFine(Fine fine){
        Fines.Add(fine);
    }

    public void FinesFromUser(string userName){
        foreach(Fine fine in Fines){
            if(fine.GetBorrow().GetPatron().getName().Equals(userName)){
                fine.FineDetails();
            }
        }
    }

    public List<Fine> GetFines() => this.Fines;
}