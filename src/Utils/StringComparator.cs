
namespace Utils;
public class StringComparator{
    public static bool compare(string actual, string compare){
        bool equals = false;
        if(actual.Equals(compare)){
            equals = true;    
        }
        return equals;
    }
}
