using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain;

public class Flight
{
    public string PilotImage { get; set; }
    public string Destination { get; set; }
    public string Departure { get; set; }
    public DateTime FlightDate { get; set; }
    public int FlightId { get; set; }
    public DateTime EffectiveArrival { get; set;}
    public int EstimatedDuration { get; set; }
    public int? PlaneFK { get; set; }
    //prop de navig
    [ForeignKey("PlaneFK")]
    public virtual Plane Plane { get; set; }
    public virtual IList<Passenger> Passengers { get; set; }
    public virtual IList<Ticket> Tickets { get; set; }
    public override string ToString()
    {
        return " Flight info = Destination :"+ Destination+
            " , Departure : " + Departure +
            " , FlightDate : "+ FlightDate+
            " , FlightId : "+ FlightId+
            " , EffectiveArrival :"+ EffectiveArrival+
            " , EstimatedDuration : "+ EstimatedDuration;
    }

}
