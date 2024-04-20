using ProjectOne.Static.Utility;

internal abstract class Menu
{
    protected abstract string Title { get; }
    protected abstract List<string> MenuOptions { get; }


    public void Render()
    {
        ConsoleInterface.ShowMainMenu(Title, MenuOptions);
    }

    public abstract Menu ManageOptions(int option);
}
