using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using FlightStatsSandbox.Models;
using FlightStatsSandbox.Services;
using FlightStatsSandbox.Services.Impl;

namespace FlightStatsSandbox.Controllers
{
    public class HomeController : Controller
    {
		public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            IGetData getFIDSData = new GetFIDSData();

            var flights = getFIDSData.GetFlights(new Request());

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";
            ViewData["ApiCall"] = flights;

            return View();
        }
    }
}
