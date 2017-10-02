public static class ProviderFactory
{
    public static Provider CreateProvider(string type, string id, double energyOutput)
    {
        if (type == "Solar")
        {
            return new SolarProvider(id, energyOutput);
        }
        else
        {
            return new PressureProvider(id, energyOutput);
        }
    }
}

