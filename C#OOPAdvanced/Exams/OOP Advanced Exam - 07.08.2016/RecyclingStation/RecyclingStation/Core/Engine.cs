using System;

namespace RecyclingStation.Core
{
    using System.Reflection;
    using Interfaces;
    using UI;

    public class Engine
        : IRunnable, IEngine
    {
        public Engine(ICommandHandler commandHandler, IReader reader, IWriter writer)
        {
            this.CommandHandler = commandHandler;
            this.Reader = reader;
            this.Writer = writer;
        }

        public Engine()
            : this(new CommandHandler(), new ConsoleReader(), new ConsoleWriter())
        {
        }

        public ICommandHandler CommandHandler { get; }
        public IReader Reader { get; }
        public IWriter Writer { get; }

        public void Run()
        {
            var input = this.Reader.ReadLine();

            while (input != "TimeToRecycle")
            {
                string[] tokens = input.Split();
                string methodName = tokens[0];

                object[] invokeParams = new object[0];

                if (tokens.Length > 1)
                {
                    invokeParams = new object[1];
                    invokeParams[0] = tokens[1]
                      .Split('|');
                }

                try
                {
                    MethodInfo method = this.CommandHandler.GetType().GetMethod(methodName);

                    if (method == null)
                    {
                        throw new ArgumentException("Invalid passed in command!");
                    }

                    this.Writer.WriteLine((string)method.Invoke(this.CommandHandler, invokeParams));
                }
                catch (ArgumentException e)
                {
                    this.Writer.WriteLine(e.Message);
                }

                input = this.Reader.ReadLine();
            }

        }
    }
}
