using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace AM.ApplicationCore.Tests
{
    [TestFixture] // Indique que cette classe contient des tests NUnit
    public class ServicePlaneTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly ServicePlane _servicePlane;

        public ServicePlaneTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _servicePlane = new ServicePlane(_mockUnitOfWork.Object);
        }

        [Test] // Remplace [Fact] par [Test]
        public void AvailablePlane_ShouldReturnTrue_WhenEnoughSeatsAvailable()
        {
            // Arrange
            var flight = new Flight
            {
                Tickets = new List<Ticket>
                {
                    new Ticket(),
                    new Ticket() // 2 tickets booked
                },
                Plane = new Plane { Capacity = 5 }
            };
            int nbPlaces = 2; // 2 new places to book

            // Act
            var result = _servicePlane.AvailablePlane(nbPlaces, flight);

            // Assert
            Assert.True(result);
        }

        [Test] // Remplace [Fact] par [Test]
        public void AvailablePlane_ShouldReturnFalse_WhenNotEnoughSeatsAvailable()
        {
            // Arrange
            var flight = new Flight
            {
                Tickets = new List<Ticket>
                {
                    new Ticket(),
                    new Ticket(),
                    new Ticket() // 3 tickets booked
                },
                Plane = new Plane { Capacity = 5 }
            };
            int nbPlaces = 3; // 3 new places to book

            // Act
            var result = _servicePlane.AvailablePlane(nbPlaces, flight);

            // Assert
            Assert.False(result);
        }

        // Ajoutez d'autres tests ici selon vos besoins.
    }
}
