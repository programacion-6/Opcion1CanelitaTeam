namespace FinesSystem;

public class FineManager
{
    List<Fine> Fines;
    
    public FineManager()
    {
        Fines = new List<Fine>();
    }

    public void AddFine(Fine fine)
    {
        if (Fines.Exists(f => f.GetBorrow().Equals(fine.GetBorrow())))
        {
            throw new InvalidOperationException("A fine already exists for this borrow record.");
        }
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
