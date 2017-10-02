using System;
using System.Linq;

public class DateModifier
{
    private long difference;

    public void GetDifference(string str1, string str2)
    {
        var date1 = str1.Split(' ').Select(int.Parse).ToArray();
        var date2 = str2.Split(' ').Select(int.Parse).ToArray();

        DateTime firstDate = new DateTime(date1[0], date1[1], date1[2]);
        DateTime secondDate = new DateTime(date2[0], date2[1], date2[2]);

        Console.WriteLine(Math.Abs((firstDate - secondDate).TotalDays));
    }

}

