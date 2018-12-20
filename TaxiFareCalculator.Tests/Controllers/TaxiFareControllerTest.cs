using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiFareCalculator;
using TaxiFareCalculator.Controllers;
using TaxiFareCalculator.Models;

namespace TaxiFareCalculator.Tests.Controllers
{
    [TestClass]
    public class TaxiFareControllerTest
    {
        [TestMethod]
        public void GetFareTest()
        {
            // Arrange
            TaxiFare taxiFare = new TaxiFare();
            JsonResult ExpectedResult = new JsonResult //format the result as Json so it can be compared to the Actual Result
            {
                Data = 9.75,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            //Values from the example given on the instruction 
            taxiFare.DateOfTrip = Convert.ToDateTime("10/08/2010 05:30:00 PM");
            taxiFare.TimeOfTrip = Convert.ToDateTime("10/08/2010 05:30:00 PM");
            taxiFare.DistanceTraveledUnder6Mph = 2.0; //2 miles
            taxiFare.TimeTraveledOver6Mph = 5; //5 min

            // Act
            TaxiFareController tfc = new TaxiFareController();
            JsonResult ActualResult = tfc.GetFare(taxiFare);

            // Assert
            Assert.AreEqual(ExpectedResult.Data, ActualResult.Data);
        }
    }
}
