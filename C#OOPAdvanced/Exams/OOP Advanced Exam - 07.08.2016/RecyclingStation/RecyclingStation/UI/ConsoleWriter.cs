namespace RecyclingStation.UI
{
    using System;
    using Interfaces;

    public class ConsoleWriter
        : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
