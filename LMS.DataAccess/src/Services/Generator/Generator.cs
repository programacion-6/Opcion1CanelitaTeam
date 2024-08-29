public class Generator
{
    private static int ISBN = 1000000000;
    private static int MembershipNumber = 1000000000;
    public static string GenerateISBN() => ISBN++.ToString();
    public static int GenerateMembershipNumber() => MembershipNumber++;
}
