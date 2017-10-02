using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Startup
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        Dictionary<string, List<Employee>> departments = new Dictionary<string, List<Employee>>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var name = input[0];
            var salary = double.Parse(input[1]);
            var position = input[2];
            var department = input[3];
            var email = "n/a";
            var age = -1;

            if (input.Length > 4)
            {
                string agePattern = "\\d+";
                if (input.Length == 5)
                {
                    if (Regex.IsMatch(input[4], agePattern))
                    {
                        age = int.Parse(input[4]);
                    }
                    else
                    {
                        email = input[4];
                    }
                }
                else
                {
                    if (Regex.IsMatch(input[4], agePattern))
                    {
                        age = int.Parse(input[4]);
                        email = input[5];
                    }
                    else
                    {
                        email = input[4];
                        age = int.Parse(input[5]);

                    }
                }
            }

            Employee currentEmployee = new Employee(name, salary, position, department, email, age);
            if (!departments.ContainsKey(department))
            {
                var employeesBuffer = new List<Employee>();
                employeesBuffer.Add(currentEmployee);

                departments.Add(department, employeesBuffer);
            }
            else
            {
                departments[department].Add(currentEmployee);
            }
            
        }

        var bestDepartment = departments.OrderByDescending(d => d.Value.Sum(e => e.Salary)).FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {bestDepartment.Key}");

        foreach (var emp in bestDepartment.Value.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
        }
    }
}

