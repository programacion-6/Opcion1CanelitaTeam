using LMS.DataAccess.UserSystem.Concretes;
using LMS.DataAccess.UserSystem.Entities;

namespace LMS.DataAccess.UserSystem.Creator;

public class StaffCreator : UserCreator
{
    public User CreateUser(string Name, int MemberShipNumber, int PhoneNumber, string Direction, string Password)
    {
        return new Staff(Name, MemberShipNumber, PhoneNumber, Direction, Password);
    }
}