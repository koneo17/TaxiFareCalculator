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
    public class HomeControllerTest
    {
        [TestMethod]
        public void TaxiFare()
        {
            // Arrange
            HomeController controller = new HomeController(); 

            // Act
            ViewResult result = controller.TaxiFare() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
