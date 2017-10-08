using System;
using FlightStatsSandbox.Types;

namespace FlightStatsSandbox.Helpers.Impl
{
    public class FidsAppSettings : IAppSettings
    {
        public string AppID => "1130f1f2";

        public string AppKey => "7f8f6c69145c0ace13a864b068c92eb9";

		public string[] RequestedFields => new string[] {"airlineCode",
                            		                  "airlineCode",
                            		                  "city",
                            		                  "currentTime",
                            		                  "currentDate",
                            		                  "flight",
                            		                  "terminal",
                            		                  "delayed",
                            		                  "gate",
                            		                  "scheduledTime",
                            		                  "scheduledDate",
                            		                  "lastUpdatedDate",
                            		                  "lastUpdatedTime",
                            		                  "statusCode",
                            		                  "destinationAirportCode",
                            		                  "airlineName",
                            		                  "airlineCode",
                            		                  "airlineLogoUrlPng",
                            		                  "destinationAirportName",
                            		                  "destinationCountryCode",
                            		                  "destinationCity",
                            		                  "destinationStateCode",
                            		                  "remarksWithTime",
                            		                  "remarksCode",
                            		                  "remarks",
                            		                  "airportCode",
                            		                  "airportName",
                            		                  "originCity",
                            		                  "originCountryCode",
                            		                  "originStateCode"};

        public string[] OrderByFields => new string[] { };

        public bool ExcludeCargoOnlyFlights => true;

        public string AirportCode => "ATH";

        public int MinutesBeforeNow => 480;

        public int MinutesAfterNow => 1440;

        public TimeFormatEnum TimeFormat => TimeFormatEnum.Hours24;

        public int LateMinutes => 15;

        public bool UseRunwayTimes => false;

    }
}
