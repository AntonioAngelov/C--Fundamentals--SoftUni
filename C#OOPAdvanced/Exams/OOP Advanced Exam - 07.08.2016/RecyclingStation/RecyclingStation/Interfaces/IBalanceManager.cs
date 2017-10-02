namespace RecyclingStation.Interfaces
{
    using WasteDisposal.Interfaces;

    public interface IBalanceManager
    {
        double EnergyBalance { get; }

        double CapitalBalance { get; }

        void ApplyProcessedResult(IProcessingData data);

        IManagementRequirement ManagemenentRequirement { get; set; }

        bool CheckWasteForProcessing(IWaste garbage);
    }
}
