using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiFareCalculator.Models
{
    public class TaxiFare
    {
        public double BaseFare = 3;
        
        public double AdditionalUnitFare { get; set; }

        public double DistanceUnit { get; set; }

        public DateTime DateOfTrip { get; set; }

        public DateTime TimeOfTrip { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public double DistanceTraveledUnder6Mph { get; set; }

        public double TimeTraveledUnder6Mph { get; set; }

        public double TimeTraveledOver6Mph { get; set; }

        public double PeekHourWeekdaySurcharge { get; set; }

        public double NYSTaxSurcharge { get; set; }


        public double GetFareForTravelUnder6mph ()
        {
            return DistanceTraveledUnder6Mph * AdditionalUnitFare * DistanceUnit;
        }

        public double GetFareForTravelOver6mph()
        {
            return TimeTraveledOver6Mph * AdditionalUnitFare;
        }

        public double GetNightSurcharge()
        {
            double Surcharge = 0;
            if (TimeOfTrip > Convert.ToDateTime(("8:00:00 PM")) && TimeOfTrip < Convert.ToDateTime(("6:00:00 AM")))
                Surcharge = .50;
            return Surcharge;
        }

        public double GetPeakHourSurcharge()
        {
            double Surcharge = 0;
            if ((DateOfTrip.DayOfWeek != DayOfWeek.Saturday && DateOfTrip.DayOfWeek != DayOfWeek.Sunday) &&
                TimeOfTrip > Convert.ToDateTime(("4:00:00 PM")) && TimeOfTrip < Convert.ToDateTime(("8:00:00 PM")))
                Surcharge = 1.00;
            return Surcharge;
        }

        public double GetNYSTaxSurcharge()
        {
            return .50;
        }

        public double GetFareForTrip()
        {
            double Total = 0;

            Total = GetFareForTravelUnder6mph() + GetFareForTravelOver6mph() + GetNightSurcharge() +
                GetPeakHourSurcharge() + GetNYSTaxSurcharge();

            return Total;
        }
    }
}