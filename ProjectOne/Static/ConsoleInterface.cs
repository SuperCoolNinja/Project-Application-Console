namespace ProjectOne.Static;

internal static class ConsoleInterface
{
    public static int GetUserOption()
    {
        int input = -1;
        
        Console.Write("Choose an option: ");

        while (!Int32.TryParse(Console.ReadLine(), out input) || input < 0 || input > 2)
            Console.Write($"Choose an option between [0 - 2]");

        return input;
    }

    public static void OpenMenu(int userOptionChoice, ref bool isRendering)
    {
       
    }
}
