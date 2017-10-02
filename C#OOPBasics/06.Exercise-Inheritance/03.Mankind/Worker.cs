using System;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName,decimal weekSalary, decimal workHours)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHours;
    }

    public decimal WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHoursPerDay = value;
        }
    }


    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    public decimal GetSalaryPerHour()
    {
        return this.WeekSalary / (5 * this.WorkHoursPerDay);
    }

    public override string ToString()
    {
        return base.ToString() +
               $"Week Salary: {this.WeekSalary:f2}\nHours per day: {this.WorkHoursPerDay:f2}\nSalary per hour: {this.GetSalaryPerHour():f2}";
    }
}

