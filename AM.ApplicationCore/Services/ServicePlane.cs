using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        //Le service IsAvailablePlane qui retourne true si on peut réserver n place à un vol passé en paramètre.
        public bool AvailablePlane(int nbPlaces, Flight flight)
        {
            return flight.Tickets.Count + nbPlaces <= flight.Plane.Capacity;
        }
        //Le service DeletePlanes qui supprime tous les avions dont la date de fabrication a dépassé 10 ans
        public void DeleteOldPlanes()
        {
            Delete(p => p.ManufactureDate.AddYears(10) <= DateTime.Now);
        }

        //Le service GetFlights qui retourne les vols ordonnés date de départ des n derniers avions.
        public IList<Flight> GetFlightsOrdered(int nbPlanes)
        {
            return GetAll().TakeLast(nbPlanes).
                SelectMany(f => f.Flights).
                OrderByDescending(f => f.FlightDate).
                ToList();
        }

        public IList<Passenger> GetPassengerByPlane(Plane plane)
        {
            // si many to many
            //return plane.Flights.SelectMany(p=>p.Passengers).ToList();
            // si porteuse uniquement 
            return plane.Flights.SelectMany(p => p.Tickets.Select(t => t.Passenger)).ToList();
        }
    }
}
