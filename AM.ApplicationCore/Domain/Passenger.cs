using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain;

public class Passenger
{
    public FullName FullName { get; set; } // type complexe
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]// calender
    public DateTime BirthDate { get; set; }
    [Key]
    [StringLength(7)]//fixed lenght
    public string PassportNumber { get; set; }
    //[DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string EmailAddress { get; set; }
    
    [RegularExpression(@"^[0-9]{8}$")]
    public string TelNumber { get; set; }
    // prop de navig
    public virtual IList<Flight> Flights { get; set; }
    public virtual IList<Ticket> Tickets { get; set; }
    public override string ToString()
    {
        return " Passenger info = BirthDate : " + BirthDate +

            " , PassportNumber: " + PassportNumber +
            " , EmailAddress: " + EmailAddress +
            " , FirstName: " + FullName.FirstName +
            " , LastName: " + FullName.LastName +
            " , TelNumber: " + TelNumber;
    }

    public bool CheckProfile(string firstName,string lastName)
    {
        return FullName.FirstName == firstName && FullName.LastName == lastName;
    }
    public bool CheckProfile(string firstName, string lastName,string email)
    {
        return FullName.FirstName == firstName && FullName.LastName == lastName && EmailAddress ==email;
    }

    public bool CheckProfile2(string firstName, string lastName, string? email=null) //? : nullable
    {
        if(email != null)
            return CheckProfile(firstName, lastName, email);
        else return CheckProfile(firstName, lastName);
    }

    public virtual string PassengerType()
    {
        return " I am a passenger !!";
    }
}
