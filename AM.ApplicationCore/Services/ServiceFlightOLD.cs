using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlightOLD
    {
        public List<Flight> Flights { get; set; }=new List<Flight>();

        public IList<DateTime> GetFlightDates(string destination)
        {
            
            //for
            //IList<DateTime> result = new List<DateTime>();
            /*for (int i = 0; i < Flights.Count; i++) 
                {
                    if (Flights[i].Destination == destination)
                        result.Add(Flights[i].FlightDate);
                }*/

            /*foreach (var flight in Flights) 
            {
                if (flight.Destination == destination)
                    result.Add(flight.FlightDate);
            }
            return result;*/

            //linq
            /*var query = from flight in Flights
                        where flight.Destination == destination
                        select flight.FlightDate;
            return query.ToList();*/

            //lambda

            return Flights.Where(f=>f.Destination == destination)
                .Select(f=>f.FlightDate).ToList();

        }
        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "EffectiveArrival":
                    foreach (Flight f in Flights)
                    {
                        if (f.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }
        }
        public void ShowFlightDetails(Plane plane)
        {
            //linq
            /*var query = from f in Flights
                        where f.Plane == plane
                        select new {f.FlightDate,f.Destination };*/
            //lambda
            var query = Flights.Where(f=> f.Plane == plane).
                Select(f => new { f.FlightDate, f.Destination }).ToList();

            foreach (var f in query)
            {
                Console.WriteLine(f.Destination+" , "+f.FlightDate);
            }
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            /*var query = from f in Flights
                        where f.FlightDate <= startDate && f.FlightDate >= startDate.AddDays(7)
                        select f;
            return query.Count();*/


            /*return Flights.Where(f => f.FlightDate <= startDate && f.FlightDate >= startDate.AddDays(7))
                .Count();*/

            return Flights.Count(f => f.FlightDate <= startDate && f.FlightDate >= startDate.AddDays(7));
                
        }
        public double DurationAverage(string destination)
        {

            /*return     (from f in Flights
                        where f.Destination == destination
                        select f.EstimatedDuration).Average();*/

            //return Flights.Where(f=> f.Destination == destination).Select(f=>f.EstimatedDuration).Average();
            return Flights.Where(f => f.Destination == destination).Average(f => f.EstimatedDuration);
        }
        public IList<Flight> OrderedDurationFlights()
        {
            /*return (from f in Flights
                   orderby f.EstimatedDuration descending
                   select f).ToList();*/

            return Flights.OrderByDescending(f => f.EstimatedDuration).ToList();
        }
        public IList<Passenger> SeniorTravellers(Flight flight)
        {
            /*return (from p in flight.Passengers
                   where p is Traveller //type passenger
                   orderby p.BirthDate ascending
                   select p).Take(3).ToList();*/

            return flight.Passengers.Where(p=>p is Traveller).OrderBy(t => t.BirthDate).Take(3).ToList();

        }
        public IList<Traveller> SeniorTravellers2(Flight flight)
        {
            /*return (from p in flight.Passengers.OfType<Traveller>()//type traveller
                    orderby p.BirthDate ascending
                    select p).Take(3).ToList();*/
            return flight.Passengers.OfType<Traveller>().OrderBy(t => t.BirthDate).Take(3).ToList();
        }

        public void DestinationGroupedFlights()
        {
            /*var query = from f in Flights
                        group f by f.Destination; //Key*/
            foreach (var item in Flights.GroupBy(f=>f.Destination)) 
            {
                Console.WriteLine(" Destination : "+item.Key); //Destination
                foreach (var item2 in item)
                { 
                    Console.WriteLine(" Décollage :" + item2.FlightDate);
                }
            }
        }
    }
}
