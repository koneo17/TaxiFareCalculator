using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxiFareCalculator.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace TaxiFareCalculator.Controllers
{
    public class TaxiFareController : Controller
    {
        public static double BaseFare = 3; //Base fare
        public static double AdditionalFee = .35; // $.35 for each additional unit
        public static double DistanceUnit = 5; //1/5 of miles
        public static double NYSTaxSurcharge = .50; //NYS Tax Surcharge
        public ActionResult TaxiFare()
        {
            return View("TaxiFare");
        }
        public  JsonResult GetFare(TaxiFare taxiFare)
        {
            double Total = 0;
            Total = BaseFare + GetFareForTravelUnder6mph(taxiFare) + 
                GetFareForTravelOver6mph(taxiFare) + GetNightSurcharge(taxiFare) +
                GetPeakHourSurcharge(taxiFare) + NYSTaxSurcharge;
            
            return Json(Total, JsonRequestBehavior.AllowGet);
        }
        public  double GetFareForTravelUnder6mph(TaxiFare taxiFare)
        {
            return taxiFare.DistanceTraveledUnder6Mph * AdditionalFee * DistanceUnit;
        }

        public double GetFareForTravelOver6mph(TaxiFare taxiFare)
        {
            return taxiFare.TimeTraveledOver6Mph * AdditionalFee;
        }

        public double GetNightSurcharge(TaxiFare taxiFare)
        {
            double Surcharge = 0;
            if((taxiFare.TimeOfTrip.Hour < 12 && taxiFare.TimeOfTrip.Hour < 6) ||
                (taxiFare.TimeOfTrip.Hour >= 12 && taxiFare.TimeOfTrip.Hour > 20))
                Surcharge = .50;
            return Surcharge;
        }

        public double GetPeakHourSurcharge(TaxiFare taxiFare)
        {
            double Surcharge = 0;
            if ((taxiFare.DateOfTrip.DayOfWeek != DayOfWeek.Saturday && taxiFare.DateOfTrip.DayOfWeek != DayOfWeek.Sunday) &&
                ((taxiFare.TimeOfTrip.Hour > 16 && taxiFare.TimeOfTrip.Hour < 20)))
                Surcharge = 1.00;
            return Surcharge;
        }
    }
}