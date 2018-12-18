using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiFareCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult TaxiFare()
        {
            return View();
        }
    }
}