public class PartTimeEmployee : IEmployee
{
    private const int partialWorkHours = 20;

    private string name;
    private int workHoursPerWeek;

    public PartTimeEmployee(string name)
    {
        this.Name = name;
        this.WorkHoursPerWeek = partialWorkHours;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int WorkHoursPerWeek
    {
        get { return this.workHoursPerWeek; }
        private set { this.workHoursPerWeek = value; }
    }
}
