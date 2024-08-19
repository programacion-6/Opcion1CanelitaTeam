namespace userSystem;

using userSystem.Concrete;
using Utils;

public class StaffManager{
    List<Staff> StaffList;

    public StaffManager()
    {
        StaffList = new List<Staff>();    
    }

    public void AddStaff(Staff staff)
    {
        string staffName = staff.getName();
        if (FoundStaffByName(staffName) == null)
        {
            StaffList.Add(staff);
            Console.WriteLine($"Staff with name '{staff.getName()}' has been added.");
        }
        else
        {
            Console.WriteLine($"Staff with name '{staff.getName()}' already exists.");
        }
    }

    public void UpdateStaff(string name, string? newName = null, int? newMembershipNumber = null, int? newPhoneNumber = null, string? newDirection = null, string? newPassword = null)
    {
        Staff? staff = FoundStaffByName(name);
        if (staff != null)
        {
            if (!string.IsNullOrEmpty(newName))
            {
                staff.setName(newName);
            }
            if (newMembershipNumber.HasValue)
            {
                staff.setMemberShipNumber(newMembershipNumber.Value);
            }
            if (newPhoneNumber.HasValue)
            {
                staff.setPhoneNumber(newPhoneNumber.Value);
            }
            if (!string.IsNullOrEmpty(newDirection))
            {
                staff.setDirection(newDirection);
            }
            if (!string.IsNullOrEmpty(newPassword))
            {
                staff.setPassword(newPassword);
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
                string staffName = staff.getName();
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
                string staffName = staff.getName();
                string staffPassword = staff.getPassword();
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
