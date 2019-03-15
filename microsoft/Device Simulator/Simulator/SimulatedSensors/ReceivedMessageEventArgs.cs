namespace SimulatedSensors.Contracts
{
    /// <summary>
    /// ReceivedMessageEventArgs class
    /// Class to pass event arguments for new message received from ConnectTheDots dashboard
    /// </summary>
    public class ReceivedMessageEventArgs : System.EventArgs
    {
        // Provide one or more constructors, as well as fields and
        // accessors for the arguments.
        public C2DMessage Message { get; set; }

        public ReceivedMessageEventArgs(C2DMessage message)
        {
            Message = message;
        }
    }
}
