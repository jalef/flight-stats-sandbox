using System;
using FlightStatsSandbox.Models;
using System.Collections.Generic;

namespace FlightStatsSandbox.Services
{
    
	public interface IGetData
	{
		List<Flight> GetFlights(Request request);
		
	}

}
