﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain;
public enum PlaneType { Boing,Airbus}
public class Plane
{
    //ctor + 2tab
    public Plane()
    {
            
    }
    public Plane(int capacity, DateTime manufactureDate, int planeId, PlaneType planeType)
    {
        Capacity = capacity;
        ManufactureDate = manufactureDate;
        PlaneId = planeId;
        PlaneType = planeType;
    }
    //prop +2tab
    [Range(0,int.MaxValue)]
    public int Capacity { get; set; }
    public DateTime ManufactureDate { get; set; }
    public int PlaneId { get; set; }
    public PlaneType PlaneType { get; set; }
    //Prop de navigation
    public virtual IList<Flight> Flights { get; set; }
    public override string ToString()
    {
        return "Planeinfo info = Capacity :" + Capacity +
            " , ManufactureDate :"+ ManufactureDate 
            + ",PlaneId : " + PlaneId +
            ",PlaneType:" + PlaneType;
    }
}

