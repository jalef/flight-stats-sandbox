using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using FlightStatsSandbox.Models;
using Newtonsoft.Json;
using FlightStatsSandbox.Services.ServicesModels;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using FlightStatsSandbox.Helpers;
using FlightStatsSandbox.Helpers.Impl;

namespace FlightStatsSandbox.Services.Impl
{
    public class GetFIDSData : IGetData
    {
        public GetFIDSData()
        {
        }

        public List<Flight> GetFlights(Request request)
        {
            IApiUrlBuilder apiUrlBuilder= new FidsApiUrlBuilder();

            string url = apiUrlBuilder.BuildUrl(request);

            return ApiResponseToFlights(DeserializeApiResponse(GetFidsApiResponse(url)));
        }

		private string GetFidsApiResponse(string url)
		{
			HttpWebRequest APIrequest = (HttpWebRequest)WebRequest.Create(url);
			try
			{
				WebResponse response = APIrequest.GetResponse();
				using (Stream responseStream = response.GetResponseStream())
				{
					StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
					return reader.ReadToEnd();
				}
			}
			catch (WebException ex)
			{
				WebResponse errorResponse = ex.Response;
				using (Stream responseStream = errorResponse.GetResponseStream())
				{
					StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
					String errorText = reader.ReadToEnd();
					// log errorText
				}
				throw;
			}
		}

		private FidsDataResponse DeserializeApiResponse(string apiResponse)
        {
            return JsonConvert.DeserializeObject<FidsDataResponse>(apiResponse);
        }

		
		private List<Flight> ApiResponseToFlights (FidsDataResponse fidsDataResponse)
		{
			List<Flight> flights = new List<Flight>();

            fidsDataResponse.Flights.ForEach(item => flights.Add(new Flight
            {
                Id = item.FlightId,
                Number = item.FlightNumber,
                DisplayName = item.Flight,
                CurrentDateTime = DateTime.Parse(item.CurrentTime)
            }));

			return flights;
		}

	}
}
