using System;

public class Job
{
    private string name;
    private IEmployee employee;
    private int hoursOfWorkRequired;

    public Job(string name, int hoursOfWorkRequired, IEmployee employee)
    {
        this.name = name;
        this.employee = employee;
        this.hoursOfWorkRequired = hoursOfWorkRequired;
    }

    public bool Update()
    {
        this.hoursOfWorkRequired -= this.employee.WorkHoursPerWeek;

        if (this.hoursOfWorkRequired <= 0)
        {
            Console.WriteLine($"Job {this.name} done!");
            return false;
        }

        return true;
    }

    public override string ToString()
    {
        return $"Job: {this.name} Hours Remaining: {this.hoursOfWorkRequired}";
    }
}

