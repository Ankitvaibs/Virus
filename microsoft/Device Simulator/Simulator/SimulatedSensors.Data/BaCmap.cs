using System.Data.Linq.Mapping;

namespace SimulatedSensors.Data
{
    [Table(Name = "BACmap")]
    public class BACmap
    {
        [Column]
        public string GatewayName { get; set; }
        [Column]
        public string DeviceName { get; set; }
        [Column]
        public string ObjectType { get; set; }
        [Column]
        public string Instance { get; set; }
        [Column]
        public string Region { get; set; }
        [Column]
        public string Campus { get; set; }
        [Column]
        public string Building { get; set; }
        [Column]
        public string Floor { get; set; }
        [Column]
        public string Unit { get; set; }
        [Column]
        public string EquipmentClass { get; set; }
        [Column]
        public string EquipmentModel { get; set; }
        [Column]
        public string SubsystemClass { get; set; }
        [Column]
        public string SubsystemModel { get; set; }
        [Column]
        public string TagName { get; set; }
    }
}
