internal class MainMenuHandler : Menu
{
    public override void Render()
    {
        Console.WriteLine("Main Menu:");
        string[] items = { "Menu Students", "Menu Courses", "Exit" };
        for (int i = 0; i < items.Length; i++)
            Console.WriteLine($"{i} - {items[i]}");
    }
}
