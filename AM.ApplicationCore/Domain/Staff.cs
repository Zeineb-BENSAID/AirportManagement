﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff:Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency)]//$ , £ ....
        public float Salary { get; set; }
        public override string ToString()
        {
            return base.ToString()+ " STAFF = EmployementDate : " + EmploymentDate + " , Salary :"
                + Salary + ",Function : " + Function;
        }

        public override string PassengerType()
        {
            return base.PassengerType()+" and i am a Staff member !! ";
        }
    }
}
