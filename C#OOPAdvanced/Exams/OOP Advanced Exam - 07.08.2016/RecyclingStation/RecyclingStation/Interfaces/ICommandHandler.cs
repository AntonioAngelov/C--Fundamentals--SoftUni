namespace RecyclingStation.Interfaces
{
    using WasteDisposal.Interfaces;

    public interface ICommandHandler
    {
        IGarbageProcessor GarbageProcessor { get; }

        IBalanceManager BalanceManager { get; }

        string ProcessGarbage(string[] parameters);

        string Status();

        string ChangeManagementRequirement(string[] parameters);
    }
}
