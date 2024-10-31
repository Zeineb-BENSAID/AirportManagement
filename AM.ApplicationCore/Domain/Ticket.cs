using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public float Price { get; set; }
        public int Seat { get; set; }
        public bool VIP { get; set; }

        public int FlightFK { get; set; }
        public string PassengerFK { get; set; }

        // prop de navigation 
        //[ForeignKey("FlightFK")]
        public virtual Flight Flight  { get; set; }
        //[ForeignKey("PassengerFK")]
        public virtual Passenger Passenger { get; set; }
    }
}
