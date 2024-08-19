namespace LibraryConsole.Utils;
public class MenuGenerator{
    public static void genericMenu(string title, List<string> options)
        {
            Console.WriteLine($"===== {title} =====");

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
        }
}