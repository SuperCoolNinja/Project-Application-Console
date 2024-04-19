internal abstract class Menu
{
    protected abstract string Title { get; }
    protected abstract List<string> MenuOptions { get; }


    public void Render()
    {
        Console.WriteLine($"{Title} :");

        for (int i = 0; i < MenuOptions.Count; i++)
            Console.WriteLine($"{i + 1} - {MenuOptions[i]}");
    }

    public abstract Menu ManageOptions(int option);
}
