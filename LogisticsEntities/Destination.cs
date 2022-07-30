using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsEntities
{
    public class Destination
    {
        public  int destinationID { get; set; }
        public string destinationState{ get; set; }
        public string destinationCity { get; set; }
        public int distance{ get; set; }
    }
}
