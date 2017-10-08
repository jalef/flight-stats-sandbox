using System.Collections.Generic;
using System.Web.Mvc;
using FlightStatsSandbox.Models;
using FlightStatsSandbox.Services;

namespace FlightStatsSandbox.Controllers
{
    public class HomeController : Controller
    {
		private readonly IGetData _getFIDSData;
		
		public HomeController(IGetData getFIDSData)
		{
			_getFIDSData = getFIDSData;
		}

		public ActionResult Index()
        {
            List<Flight> flights = _getFIDSData.GetFlights(new Request());

            ViewData["ApiCall"] = flights;

            return View();
        }
    }
}