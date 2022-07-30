using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsEntities
{
    public class Truck
    {
        public string truckID { get; set; }
        public int vendorID { get; set; }
        public int costPerKM { get; set; }
        public int assignedTripID { get; set; }

    }
}
