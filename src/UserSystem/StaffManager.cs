namespace userSystem;

using Interfaces;
using userSystem.Concrete;
using Utils;

public class StaffManager{
    private readonly IUserRepository _repository;
    
    List<Staff> StaffList;

    public StaffManager(IUserRepository repository)
    {
        _repository = repository;
    }

    public void AddStaff(Staff staff)
    {
        string staffName = staff.Name;
        if (FoundStaffByName(staffName) == null)
        {
            StaffList.Add(staff);
            Console.WriteLine($"Staff with name '{staff.Name}' has been added.");
        }
        else
        {
            Console.WriteLine($"Staff with name '{staff.Name}' already exists.");
        }
    }

    public void UpdateStaff(string name, string? newName = null, int? newMembershipNumber = null, int? newPhoneNumber = null, string? newDirection = null, string? newPassword = null)
    {
        Staff? staff = FoundStaffByName(name);
        if (staff != null)
        {
            if (!string.IsNullOrEmpty(newName))
            {
                staff.Name = newName;
            }
            if (newMembershipNumber.HasValue)
            {
                staff.MemberShipNumber =newMembershipNumber.Value;
            }
            if (newPhoneNumber.HasValue)
            {
                staff.PhoneNumber = newPhoneNumber.Value;
            }
            if (!string.IsNullOrEmpty(newDirection))
            {
                staff.Direction = newDirection;
            }
            if (!string.IsNullOrEmpty(newPassword))
            {
                staff.Password = newPassword;
            }
            Console.WriteLine($"Staff with name '{name}' has been updated.");
        }
        else
        {
            Console.WriteLine($"Staff with name '{name}' not found.");
        }
    }

    public void RemoveStaff(string name)
    {
        Staff? staff = FoundStaffByName(name);
        if (staff != null)
        {
            StaffList.Remove(staff);
            Console.WriteLine($"Staff with name '{name}' has been removed.");
        }
        else
        {
            Console.WriteLine($"Staff with name '{name}' not found.");
        }
    }

    private Staff? FoundStaffByName(string name)
    {
        try
        {
            foreach (Staff staff in StaffList)
            {
                string staffName = staff.Name;
                if (StringComparator.compare(staffName, name))
                {
                    return staff;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while searching for the staff: {ex.Message}");
        }

        return null;
    }

     public Staff? ValidateStaff(string name, string password)
    {
        try
        {
            foreach (Staff staff in StaffList)
            {
                string staffName = staff.Name;
                string staffPassword = staff.Password;
                if (StringComparator.compare(staffName, name) && StringComparator.compare(staffPassword, password))
                {
                    return staff;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid credentials: {ex.Message}");
        }

        return null;
    }

    public List<Staff> GetStaffs() => StaffList;
    public void SetStaffs(List<Staff> staffList) => this.StaffList = staffList;
}
