namespace RecyclingStation.MockedObjects
{
    using WasteDisposal.Interfaces;

    public class MockedWasteWithoutAtributes
        : IWaste
    {
        public string Name => "mockedName";
        public double VolumePerKg => 1;
        public double Weight => 1;
    }
}
