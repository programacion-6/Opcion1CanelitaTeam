using LMS.DataAccess.Console.Utils.Find;
using LMS.DataAccess.Console.Utils.Find.Concretes;
using LMS.DataAccess.Systems.Entities.User;
using LMS.DataAccess.Systems.Interfaces;
using LMS.DataAccess.Utils;

using Spectre.Console;

namespace LMS.DataAccess.Systems.Concretes.Managers;

public class StaffManager : IBaseManager<Staff>
{
    List<Staff> StaffList;

    public StaffManager()
    {
        StaffList = new List<Staff>();
    }

    public bool Add(Staff staff)
    {
        string staffName = staff.getName();
        Staff? staffAux = StaffList.Find(staff => staff.getName().Equals(staffName, StringComparison.OrdinalIgnoreCase));
        if (staffAux == null)
        {
            StaffList.Add(staff);
            System.Console.WriteLine($"Staff with name '{staff.getName()}' has been added.");
            return true;
        }
        else
        {
            System.Console.WriteLine($"Staff with name '{staff.getName()}' already exists.");
            return false;
        }
    }

    public bool Update(Staff staff)
    {
        var staffName = AnsiConsole.Ask<string>("Enter the staff name to update:");
        var staffToUpdate = StaffList.Find(staff => staff.getName().Equals(staffName, StringComparison.OrdinalIgnoreCase));
        if (staffToUpdate != null)
        {
            if (!string.IsNullOrEmpty(staff.getName()))
            {
                staffToUpdate.setName(staff.getName());
            }
            staffToUpdate.setMemberShipNumber(staff.getMemberShipNumber());
            staffToUpdate.setPhoneNumber(staff.getPhoneNumber());
            if (!string.IsNullOrEmpty(staff.getDirection()))
            {
                staffToUpdate.setDirection(staff.getDirection());
            }
            if (!string.IsNullOrEmpty(staff.getPassword()))
            {
                staffToUpdate.setPassword(staff.getPassword());
            }
            System.Console.WriteLine($"Staff with name '{staffToUpdate.getName()}' has been updated.");
            return true;
        }
        else
        {
            System.Console.WriteLine($"Staff with name '{staff.getName()}' not found.");
            return false;
        }
    }

    public bool Remove(Staff staff)
    {
        if (staff != null)
        {
            System.Console.WriteLine($"Staff with name '{staff.getName()}' has been removed.");
            StaffList.Remove(staff);
            return true;
        }
        else
        {
            System.Console.WriteLine($"Staff not found.");
            return false;
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

    public List<Staff> GetAll() => StaffList;
}
