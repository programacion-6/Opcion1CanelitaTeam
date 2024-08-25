using LMS.DataAccess.Console.Utils.Find;
using LMS.DataAccess.Console.Utils.Find.Concretes;
using LMS.DataAccess.UserSystem.Concretes;
using LMS.DataAccess.Utils;

namespace LMS.DataAccess.UserSystem;

public class StaffManager{
    List<Staff> StaffList;

    public StaffManager()
    {
        StaffList = new List<Staff>();    
    }

    public void AddStaff(Staff staff)
    {
        string staffName = staff.getName();
        Staff? staffaux = (Staff)PerformFind.Execute(new FindStaffByName(StaffList, staffName));
        if (staffaux == null)
        {
            StaffList.Add(staff);
            System.Console.WriteLine($"Staff with name '{staff.getName()}' has been added.");
        }
        else
        {
            System.Console.WriteLine($"Staff with name '{staff.getName()}' already exists.");
        }
    }

    public void UpdateStaff(string name, string? newName = null, int? newMembershipNumber = null, int? newPhoneNumber = null, string? newDirection = null, string? newPassword = null)
    {
        Staff? staff = (Staff)PerformFind.Execute(new FindStaffByName(StaffList, name));
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
            System.Console.WriteLine($"Staff with name '{name}' has been updated.");
        }
        else
        {
            System.Console.WriteLine($"Staff with name '{name}' not found.");
        }
    }

    public void RemoveStaff(string name)
    {
        Staff? staff = (Staff)PerformFind.Execute(new FindStaffByName(StaffList, name));
        if (staff != null)
        {
            StaffList.Remove(staff);
            System.Console.WriteLine($"Staff with name '{name}' has been removed.");
        }
        else
        {
            System.Console.WriteLine($"Staff with name '{name}' not found.");
        }
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
            System.Console.WriteLine($"Invalid credentials: {ex.Message}");
        }

        return null;
    }

    public List<Staff> GetStaffs() => StaffList;
    public void SetStaffs(List<Staff> staffList) => this.StaffList = staffList;
}
