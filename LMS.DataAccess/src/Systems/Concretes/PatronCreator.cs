using LMS.DataAccess.Systems.Entities.User;

namespace LMS.DataAccess.Systems.Concretes;

public class PatronCreator : UserCreator
{
    public User CreateUser(string Name, int MemberShipNumber, int PhoneNumber, string Direction, string Password)
    {
        return new Patron(Name, MemberShipNumber, PhoneNumber, Direction, Password);
    }
}
