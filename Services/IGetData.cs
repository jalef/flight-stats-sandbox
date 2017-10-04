using System;
using FlightStatsSandbox.Models;
using System.Collections.Generic;

namespace FlightStatsSandbox.Services
{
    
	public interface IGetData
	{
		void GetFlights(Request request,
                        IOnDataReadyCallback callback);
		
	}

	public interface IOnDataReadyCallback
	{
		void OnDataReady(IList<Flight> flights);
		
	}

}
