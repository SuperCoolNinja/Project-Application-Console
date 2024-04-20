namespace ProjectOne.Static.Utility;

internal static class ConsoleInterface
{
    public static int AskUserOption()
    {
        Console.Write("Choose an option: ");

        int input = -1;
        while (!int.TryParse(Console.ReadLine(), out input))
            Console.Write("Choose an option: ");

        return input;
    }
}
