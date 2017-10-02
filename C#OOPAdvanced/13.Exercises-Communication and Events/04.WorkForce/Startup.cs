using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        List<Job> jobs = new List<Job>();
        List<IEmployee> employees = new List<IEmployee>();

        var input = Console.ReadLine().Split();

        while (input[0] != "End")
        {
            switch (input[0])
            {
                case "Job":
                    var employeeForJob = employees.FirstOrDefault(e => e.Name == input[3]);
                    jobs.Add(new Job(input[1], int.Parse(input[2]), employeeForJob));
                    break;
                case "StandartEmployee":
                    employees.Add(new StandartEmployee(input[1]));
                    break;
                case "PartTimeEmployee":
                    employees.Add(new PartTimeEmployee(input[1]));
                    break;
                case "Pass":
                    int i = 0;

                    while (i < jobs.Count)
                    {
                        if (jobs[i].Update())
                        {
                            i++;
                        }
                        else
                        {
                            jobs.Remove(jobs[i]);
                        }
                    }

                    break;
                case "Status":
                    jobs.ForEach(j => Console.WriteLine(j.ToString()));
                    break;
            }

            input = Console.ReadLine().Split();
        }
    }
}

