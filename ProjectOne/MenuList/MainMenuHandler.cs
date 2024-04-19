internal class MainMenuHandler : Menu
{
    public override string Title => "Main Menu";

    public override List<string> MenuOptions => new List<string>() { "Menu Students", "Menu Courses", "Exit" };

    public override Menu ManageOptions(int options, ref bool stopRendering)
    {
        switch (options)
        {
            case 0:
                return new StudentMenuHandler();
            case 1:
                return new CourseMenuHandler();
            default:
                stopRendering = false;
                return this;
        }
    }

}
