using System;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        try
        {
            var studentInfo = Console.ReadLine()
           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
           .ToArray();

            var workerInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var student = new Student(studentInfo[0], studentInfo[1], studentInfo[2]);

            var worker = new Worker(workerInfo[0], workerInfo[1], decimal.Parse(workerInfo[2]), decimal.Parse(workerInfo[3]));

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }

    }
}
