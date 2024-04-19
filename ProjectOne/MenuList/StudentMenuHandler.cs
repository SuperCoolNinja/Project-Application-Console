using ProjectOne.Entities;
internal class StudentMenuHandler : Menu
{
    public override string Title => "Student Menu";
    public override List<string> MenuOptions => new List<string>() { "ss Test", "Exit" };

    public void ShowStudent(Student student)
    {

    }

    public override Menu ManageOptions(int options, ref bool stopRendering)
    {
        switch (options)
        {
            case 0:
                Console.WriteLine("Testing ...ss");
                return this;
            default:
                stopRendering = false;
                return this;
        }
    }

}
