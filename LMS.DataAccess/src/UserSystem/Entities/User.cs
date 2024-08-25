namespace LMS.DataAccess.UserSystem.Entities;

public abstract class User{

    protected string Name;
    protected string Password;
    protected int MemberShipNumber;
    protected int PhoneNumber;
    protected string Direction;
    public User(string Name, int MemberShipNumber, int PhoneNumber, string Direction, string Password){
        this.Name = Name;
        this.MemberShipNumber = MemberShipNumber;
        this.PhoneNumber = PhoneNumber;
        this.Direction = Direction;
        this.Password = Password;
    }
    public abstract void UserInformation();

    public string getName() => Name;
    public int getMemberShipNumber() => MemberShipNumber;
    public int getPhoneNumber() => PhoneNumber;
    public string getDirection() => Direction;
    public string getPassword() => Password;

    public void setName(string name) => Name = name;
    public void setMemberShipNumber(int number) => MemberShipNumber = number;
    public void setPhoneNumber(int number) => PhoneNumber = number;
    public void setDirection(string direction) => Direction = direction;
    public void setPassword(string password) => Password = password;
}