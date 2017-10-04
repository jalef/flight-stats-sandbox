using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using FlightStatsSandbox.Models;
using Newtonsoft.Json;
using FlightStatsSandbox.Services.ServicesModels;

namespace FlightStatsSandbox.Services.Impl
{
    public class GetFIDSData : IGetData
    {
        public GetFIDSData()
        {
        }

        public List<Flight> GetFlights(Request req)
        {
            
            string url = "https://api.flightstats.com/flex/fids/rest/v1/json/ATH/" +
                "departures?appId=1130f1f2&appKey=7f8f6c69145c0ace13a864b068c92eb9&" +
                "requestedFields=airlineCode%2CflightNumber%2Ccity%2CcurrentTime" +
                "%2CcurrentDate%2Cflight%2Cterminal%2Cdelayed%2Cgate%2CscheduledTime" +
                "%2CscheduledDate%2ClastUpdatedTime%2ClastUpdatedDate%2CstatusCode" +
                "%2CairlineName%2CairlineCode%2CairlineLogoUrlPng%2CdestinationAirportName" +
                "%2CdestinationAirportCode%2CdestinationCity%2CdestinationStateCode" +
                "%2CdestinationCountryCode%2CremarksWithTime%2CremarksCode" +
                "%2CairportCode%2CairportName%2Ccity%2CoriginCity%2CoriginCountryCode%2CoriginStateCode" +
                "%2Cremarks&" +
                "lateMinutes=15&useRunwayTimes=false&excludeCargoOnlyFlights=false";
            
            return ApiResponseToFlights(DeserializeApiResponse(GetFidsApiResponse(url)));
           
        }

		public FidsDataResponse GetFidsDataObject(Request req)
		{

			string url = "https://api.flightstats.com/flex/fids/rest/v1/json/ATH/" +
				"departures?appId=1130f1f2&appKey=7f8f6c69145c0ace13a864b068c92eb9&" +
				"requestedFields=airlineCode%2CflightNumber%2Ccity%2CcurrentTime" +
				"%2CcurrentDate%2Cflight%2Cterminal%2Cdelayed%2Cgate%2CscheduledTime" +
				"%2CscheduledDate%2ClastUpdatedTime%2ClastUpdatedDate%2CstatusCode" +
				"%2CairlineName%2CairlineCode%2CairlineLogoUrlPng%2CdestinationAirportName" +
				"%2CdestinationAirportCode%2CdestinationCity%2CdestinationStateCode" +
				"%2CdestinationCountryCode%2CremarksWithTime%2CremarksCode" +
				"%2CairportCode%2CairportName%2Ccity%2CoriginCity%2CoriginCountryCode%2CoriginStateCode" +
				"%2Cremarks&" +
				"lateMinutes=15&useRunwayTimes=false&excludeCargoOnlyFlights=false";

            return DeserializeApiResponse(GetFidsApiResponse(url));

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
