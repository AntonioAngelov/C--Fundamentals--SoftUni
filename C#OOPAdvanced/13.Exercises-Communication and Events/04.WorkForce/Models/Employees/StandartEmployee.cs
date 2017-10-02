public class StandartEmployee : IEmployee
{
    private const int standartWorkHours = 40;

    private string name;
    private int workHoursPerWeek;

    public StandartEmployee(string name)
    {
        this.Name = name;
        this.WorkHoursPerWeek = standartWorkHours;
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