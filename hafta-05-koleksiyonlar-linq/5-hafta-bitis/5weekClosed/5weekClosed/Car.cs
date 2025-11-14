using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveWeekClosed
{
    public class Car
    {
        public DateTime ProductionDate { get; set; }
        public int SeriNo { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int DoorNumber { get; set; }

        public Car() 
        {
             ProductionDate = DateTime.Now;     
        }

    }
}
