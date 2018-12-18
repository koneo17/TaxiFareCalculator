using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiFareCalculator.Controllers
{
    public class TaxiFareController : Controller
    {
        // GET: TaxiFare
        public ActionResult Index()
        {
            return View();
        }
    }
}