using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsEntities
{
    public class Trip
    {
        public int tripID { get; set; }

        public int vendorID { get; set; }
        public int driverID { get; set; }

        public string startDate { get; set; }

        public string endDate { get; set; }

        public int extraDistance { get; set; }
        public int tollCharges { get; set; }
        public int maintainceCharges { get; set; }
        public int extraCharges { get; set; }

        public int status { get; set; }
    }
}
