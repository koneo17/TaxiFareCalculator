using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiFareCalculator.Models
{
    public class TaxiFare
    {
        //Below are the 4 properties for the TaxiFare class
        public DateTime DateOfTrip { get; set; }

        public DateTime TimeOfTrip { get; set; }

        public double DistanceTraveledUnder6Mph { get; set; }

        public double TimeTraveledOver6Mph { get; set; }
    }
}