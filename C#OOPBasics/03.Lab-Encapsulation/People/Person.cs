using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string firstName, string lastName, int age, double salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value.Length >= 3)
            {
                this.firstName = value;
            }
            else
            {
                throw new ArgumentException("First name cannot be less than 3 symbols");
            }
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value.Length >= 3)
            {
                this.lastName = value;
            }
            else
            {
                throw new ArgumentException("Last name cannot be less than 3 symbols");
            }
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value > 0)
            {
                this.age = value;
            }
            else
            {
                throw new ArgumentException("Age cannot be zero or negative integer");
            }
        }
    }

    public double Salary
    {
        get { return this.salary; }
        set
        {
            if (value >= 460.0)
            {
                this.salary = value;
            }
            else
            {
              throw  new ArgumentException("Salary cannot be less than 460 leva");
            }
        }
        
    }

    //Exercise 1
    //public override string ToString()
    //{
    //    return $"{this.firstName} {this.lastName} is a {this.age} years old";
    //}

    public void IncreaseSalary(double bonus)
    {
        if (this.Age <= 30)
        {
            this.Salary += this.salary * bonus / 200;
        }
        else
        {
            this.Salary += this.salary * bonus / 100;
        }
    }

    //Exercise 2
    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} get {this.Salary:f2} leva";
    }
}

