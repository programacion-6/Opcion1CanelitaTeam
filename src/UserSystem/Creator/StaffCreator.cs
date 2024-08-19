namespace Opcion1AlexPaca.Creator;
using userSystem.Concrete;
public class StaffCreator : UserCreator
{
    public User CreateUser(string Name, int MemberShipNumber, int PhoneNumber, string Direction, string Password)
    {
        return new Staff(Name, MemberShipNumber, PhoneNumber, Direction, Password);
    }
}