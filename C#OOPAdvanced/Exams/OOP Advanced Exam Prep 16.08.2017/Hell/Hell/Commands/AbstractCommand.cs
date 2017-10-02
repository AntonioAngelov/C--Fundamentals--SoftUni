using System;
using System.Collections.Generic;
using System.Reflection;

public abstract class AbstractCommand
    : ICommand
{
    protected AbstractCommand(List<string> args, IManager manager)
    {
        this.ArgsList = args;
        this.Manager = manager;
    }

    public List<string> ArgsList { get; private set; }

    public IManager Manager { get; private set; }
    
    public abstract string Execute();
}

