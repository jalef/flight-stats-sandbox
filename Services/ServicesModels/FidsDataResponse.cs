using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FlightStatsSandbox.Services.ServicesModels
{
    public class FidsDataResponse
    {
        [JsonProperty(PropertyName = "fidsData")]
        public List<FlightResponse> Flights { get; set; }

        public FidsDataResponse()
        {
        }
    }

    public class FlightResponse
    {
        [JsonProperty(PropertyName = "flightId")]
        public string FlightId { get; set; }

		[JsonProperty(PropertyName = "lastUpdatedTime")]
		public string LastUpdatedTime { get; set; }

		[JsonProperty(PropertyName = "lastUpdatedDate")]
		public string LastUpdatedDate { get; set; }

		[JsonProperty(PropertyName = "statusCode")]
		public string StatusCode { get; set; }

		[JsonProperty(PropertyName = "airlineName")]
		public string AirlineName { get; set; }

		[JsonProperty(PropertyName = "airlineCode")]
		public string AirlineCode { get; set; }

		[JsonProperty(PropertyName = "flightNumber")]
		public string FlightNumber { get; set; }

		[JsonProperty(PropertyName = "gate")]
		public string Gate { get; set; }

		[JsonProperty(PropertyName = "terminal")]
		public string Terminal { get; set; }

		[JsonProperty(PropertyName = "airlineLogoUrlPng")]
		public string AirlineLogoUrlPng { get; set; }

		[JsonProperty(PropertyName = "airlineLogoUrlSvg")]
		public string AirlineLogoUrlSvg { get; set; }

		[JsonProperty(PropertyName = "originCity")]
		public string OriginCity { get; set; }

		[JsonProperty(PropertyName = "originStateCode")]
		public string OriginStateCode { get; set; }

		[JsonProperty(PropertyName = "originCountryCode")]
		public string OriginCountryCode { get; set; }

		[JsonProperty(PropertyName = "destinationAirportName")]
		public string DestinationAirportName { get; set; }

		[JsonProperty(PropertyName = "destinationAirportCode")]
		public string DestinationAirportCode { get; set; }

		[JsonProperty(PropertyName = "destinationCity")]
		public string DestinationCity { get; set; }

		[JsonProperty(PropertyName = "destinationStateCode")]
		public string DestinationStateCode { get; set; }

		[JsonProperty(PropertyName = "destinationCountryCode")]
		public string DestinationCountryCode { get; set; }

		[JsonProperty(PropertyName = "flight")]
		public string Flight { get; set; }

		[JsonProperty(PropertyName = "delayed")]
		public string Delayed { get; set; }

		[JsonProperty(PropertyName = "remarks")]
		public string Remarks { get; set; }

		[JsonProperty(PropertyName = "remarksWithTime")]
		public string RemarksWithTime { get; set; }

		[JsonProperty(PropertyName = "remarksCode")]
		public string RemarksCode { get; set; }

		[JsonProperty(PropertyName = "airportCode")]
		public string AirportCode { get; set; }

		[JsonProperty(PropertyName = "airportName")]
		public string AirportName { get; set; }

		[JsonProperty(PropertyName = "city")]
		public string City { get; set; }

		[JsonProperty(PropertyName = "scheduledTime")]
		public string ScheduledTime { get; set; }

		[JsonProperty(PropertyName = "currentTime")]
		public string CurrentTime { get; set; }

		[JsonProperty(PropertyName = "scheduledGateTime")]
		public string ScheduledGateTime { get; set; }

		[JsonProperty(PropertyName = "currentGateTime")]
		public string CurrentGateTime { get; set; }

		public FlightResponse()
        {
        }
    }
}
