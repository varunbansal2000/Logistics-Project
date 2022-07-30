using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsEntities
{
    public class Driver
    {
        public int driverID { get; set; }
        public string driverName {get; set;}

        public string driverContact { get; set; }

        public int driverCharges { get; set; }

        public int assignedTripID { get; set; }

    }
}
