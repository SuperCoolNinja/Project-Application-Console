internal abstract class Menu
{
    public abstract string Title { get; }
    public abstract List<string> MenuOptions { get; }
    public void Render()
    {
        Console.WriteLine($"{Title} :");

        for (int i = 0; i < MenuOptions.Count; i++)
            Console.WriteLine($"{i} - {MenuOptions[i]}");
    }

    public abstract Menu ManageOptions(int options, ref bool stopRendering);
}
