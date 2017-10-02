public class StartUp
{
    public static void Main()
    {
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();

        ItemFactory itemFactory = new ItemFactory();

        IManager manager = new HeroManager(itemFactory);
        ICommandInterpreter interpreter = new CommandInterpreter(manager);

        Engine engine = new Engine(reader, writer, interpreter);
        engine.Run();
    }
}