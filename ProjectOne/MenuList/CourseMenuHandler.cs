
internal class CourseMenuHandler : Menu
{
    public override string Title => "Courses Menu";

    public override List<string> MenuOptions => new List<string>() { "Test", "Exit" };

    public override Menu ManageOptions(int options, ref bool stopRendering)
    {

        switch (options)
        {
            case 0:
                Console.WriteLine("Testing....");
                return this;
            default:
                stopRendering = false;
                return this;
        }
    }
}
