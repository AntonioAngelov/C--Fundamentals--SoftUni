namespace RecyclingStation.Interfaces
{
    public interface IEngine
    {
        ICommandHandler CommandHandler { get; }

        IReader Reader { get; }

        IWriter Writer { get; }
    }
}
