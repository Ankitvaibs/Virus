namespace SimulatedSensors.Contracts
{
    public interface IAsset
    {
        string Id { get; }

        bool StateChanged { get; }

        SimulatorMessage GetMessage();
    }
}