using System.Runtime.Serialization;

namespace SimulatedSensors.Contracts
{
    /// <summary>
    /// Data contract defining Connect The Dots Cloud to Device message format
    /// </summary>
    [DataContract]
    public class C2DMessage
    {
        [DataMember]
        public string alerttype;

        [DataMember]
        public string message;

        [DataMember]
        public string guid;

        [DataMember]
        public string displayname;

        [DataMember]
        public string organization;

        [DataMember]
        public string location;

        [DataMember]
        public string measurename;

        [DataMember]
        public string unitofmeasure;

        [DataMember]
        public string timecreated;

        [DataMember]
        public double value;

    }
}