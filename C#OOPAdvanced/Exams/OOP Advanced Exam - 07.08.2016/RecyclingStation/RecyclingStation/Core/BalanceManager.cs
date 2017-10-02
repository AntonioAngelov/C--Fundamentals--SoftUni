namespace RecyclingStation.Core
{
    using Interfaces;
    using WasteDisposal.Interfaces;

    public class BalanceManager
        : IBalanceManager
    {
        private double energyBalance;
        private double capitalBalance;
        private IManagementRequirement managementRequirement;

        public BalanceManager()
        {
            this.EnergyBalance = 0;
            this.CapitalBalance = 0;
            this.ManagemenentRequirement = null;
        }

        public double EnergyBalance { get; private set; }

        public double CapitalBalance { get; private set; }

        public IManagementRequirement ManagemenentRequirement
        {
            get { return this.managementRequirement; }
            set { this.managementRequirement = value; }
        }

        public void ApplyProcessedResult(IProcessingData data)
        {
            this.EnergyBalance += data.EnergyBalance;
            this.CapitalBalance += data.CapitalBalance;
        }

        public bool CheckWasteForProcessing(IWaste garbage)
        {
            if (this.ManagemenentRequirement == null)
            {
                return true;
            }

            return this.ManagemenentRequirement.CheckWasteForProcessing(this.EnergyBalance, this.CapitalBalance, garbage);
        }
        
    }
}
