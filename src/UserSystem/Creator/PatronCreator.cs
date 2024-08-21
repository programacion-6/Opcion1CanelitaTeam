namespace Opcion1AlexPaca.Creator;
using userSystem.Concrete;
public class PatronCreator : UserCreator
{
    public User CreateUser(string Name, int MemberShipNumber, int PhoneNumber, string Direction, string Password)
    {
        return new Patron(Name, MemberShipNumber, PhoneNumber, Direction, Password);
    }
}
