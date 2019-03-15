using System.Data.Linq;

namespace SimulatedSensors.Data
{
    public class SmartBuildingContext : DataContext
    {
        public SmartBuildingContext(string connectionString) : base(connectionString)
        {
        }

        public Table<BACmap> BACmap;
    }
}