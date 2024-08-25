using LMS.DataAccess.Utils;

namespace LMS.DataAccess;

class Program
{
    static void Main(string[] args)
    {
        PrepareData.PrepareLibrary().InitializeProgram();
    }
}
