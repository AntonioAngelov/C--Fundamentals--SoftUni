using System;

namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public class FightCommand : Command
    {
        public FightCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);

            return "End";
        }
    }
}
