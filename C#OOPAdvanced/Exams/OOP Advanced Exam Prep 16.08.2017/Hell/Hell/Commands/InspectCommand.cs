using System.Collections.Generic;

public class InspectCommand
    : AbstractCommand
{
    public InspectCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.Inspect(this.ArgsList);
    }
}
