using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsEntities
{
    public class Summary
    {

        public int summaryID { get; set; }
        public int tripID { get; set; }
        public int fromABC { get; set; }
        public int vendorCharges { get; set; }
        public int driverCharges { get; set; }
        public int extraCharges { get; set; }
        public int profitLoss { get; set; }

    }
}
