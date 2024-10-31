using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane:IService<Plane>
    {
        //siganture des méthodes spécifiques
        IList<Passenger> GetPassengerByPlane(Plane p);
        IList<Flight> GetFlightsOrdered(int nbPlanes);
        bool AvailablePlane(int nbPlaces, Flight flight);
        void DeleteOldPlanes();
    }
}
