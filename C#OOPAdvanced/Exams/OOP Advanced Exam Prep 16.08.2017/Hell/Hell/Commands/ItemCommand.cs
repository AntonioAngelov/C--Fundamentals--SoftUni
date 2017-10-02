using System;
using System.Collections.Generic;
using System.Reflection;

public class ItemCommand
    : AbstractCommand
{
    public ItemCommand(List<string> args, IManager manager) 
        : base(args, manager)
    {
    }

    public override string Execute()
    {

        return this.Manager.AddItemToHero(this.ArgsList);
    }
}

