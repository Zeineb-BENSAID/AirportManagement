// See https://aka.ms/new-console-template for more information


using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");

#region TP1
// constructeur vide
Plane plane = new Plane();
plane.Capacity = 1;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Boing;
plane.PlaneId = 1;

//cw +2 tab
Console.WriteLine(plane.ToString());

//constructeur paramétré
Plane plane1 = new Plane(130,DateTime.Now,2,PlaneType.Boing);
Console.WriteLine(plane1.ToString());

//Initialiseur d'objet

Plane plane2 = new Plane() 
{ 
    PlaneType = PlaneType.Boing,
    Capacity = 100,
};
Plane plane3 = new Plane()
{
    PlaneId = 3,    
    Capacity = 150,
};

Console.WriteLine(plane2.ToString());
Console.WriteLine(plane3.ToString());

Passenger passenger = new Passenger()
{
    FullName = new FullName
    {
        FirstName = "Aya",
        LastName = "Bani"
    },
    BirthDate=new DateTime(2000,10,10),
    EmailAddress="aya.bani@esprit.tn",
    PassportNumber="ZE456GHT",
    TelNumber="20123456"
};
Staff staff = new Staff()
{
    FullName = new FullName
    {
        FirstName = "bilel",
        LastName = "mahmoudi"
    },
    BirthDate = new DateTime(2000, 10, 10),
    EmailAddress = "bilel.mahmoudi@esprit.tn",
    PassportNumber = "ZE456GHT",
    TelNumber = "99123456",
    EmploymentDate=DateTime.Now,
    Function="Captain",
    Salary=20000
};

Console.WriteLine(passenger.CheckProfile2("Aya", "Bani"));//true
Console.WriteLine(passenger.CheckProfile2("Aya", "mahmoudi", "bilel.mahmoudi@esprit.tn"));//false

Console.WriteLine(passenger.PassengerType());
Console.WriteLine(staff.PassengerType());
#endregion
#region TP2
//ServiceFlight sf = new ServiceFlight();
//sf.Flights = TestData.listFlights;


//sf.DestinationGroupedFlights();
//Console.WriteLine(sf......) ;
#endregion