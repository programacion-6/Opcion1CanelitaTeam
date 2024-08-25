using LMS.DataAccess.Console.Utils.Find.Interfaces;

namespace LMS.DataAccess.Console.Utils.Find;

public class PerformFind{
    public static Object Execute(FindProcess Find){
        return Find.FindItem();
    }
}