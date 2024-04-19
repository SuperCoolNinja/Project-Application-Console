namespace ProjectOne.Static;

internal static class ConsoleInterface
{
    public static int AskUserOption()
    {
        Console.Write("Choose an option: ");

        int input = -1;
        while (!Int32.TryParse(Console.ReadLine(), out input))
            Console.Write("Choose an option: ");

        return input;
    }
}
