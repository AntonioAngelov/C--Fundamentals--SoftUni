namespace _03.CubicMessages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var inputMessage = Console.ReadLine();

                if (inputMessage == "Over!")
                {
                    break;
                }

                var lenght = int.Parse(Console.ReadLine());

                var messagePattern = string.Format("^([0-9]+)([a-zA-Z]{{{0}}})([^a-zA-Z]*)$", lenght);
                Regex regex = new Regex(messagePattern);

                var match = regex.Match(inputMessage);

                if (match.Success)
                {
                    var message = match.Groups[2].Value;
                    var digitsBeforeMessage = match.Groups[1].Value;
                    var charsAfteMessage = match.Groups[3].Value;
                    var digits = digitsBeforeMessage + charsAfteMessage;

                    StringBuilder verificationCode = new StringBuilder();
                    List<int> indexes = new List<int>();

                    for (int i = 0; i < digits.Length; i++)
                    {
                        if (char.IsDigit(digits[i]))
                        {
                            var index = int.Parse(digits[i].ToString());

                            indexes.Add(index);
                        }

                    }

                    foreach (var index in indexes)
                    {
                        if (index < lenght)
                        {
                            verificationCode.Append(message[index]);
                        }
                        else
                        {
                            verificationCode.Append(" ");
                        }
                    }

                    Console.WriteLine($"{message} == {verificationCode}");

                }
            }
        }
    }
}
