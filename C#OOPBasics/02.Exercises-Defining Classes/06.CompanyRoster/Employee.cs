public class Employee
{
    public Employee(string name, double salary,
        string position, string depatment,
        string email, int age)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = depatment;
        this.Email = email;
        this.Age = age;
    }
    

    public string Name { get; set; }

    public double Salary { get; set; }

    public string Position { get; set; }

    public string Department { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }
}

