using System;
using FlightStatsSandbox.Types;

namespace FlightStatsSandbox.Models
{

    public class Flight
    {
        public Request Request { get; set; }
		public string Id { get; set; }
        public string Number { get; set; }
        public DateTime UpdatedTime { get; set; }
        public FlightStatusEnum Status { get; set; }
        public Airline Airline { get; set; }
        public City OriginCity {get; set; }
        public City Destination { get; set; }
        public Airport DestinationAirport { get; set; }
        public Airport OriginAirport { get; set; }
        public string Gate { get; set; }
        public string Terminal { get; set; }
        public string DisplayName { get; set; }
        public Boolean Delayed { get; set; }
        public string RemarksText { get; set; }
        public string RemarksOnTime { get; set; }
        public RemarksEnum Remarks { get; set; }
        public DateTime ScheduledTime { get; set; }
        public DateTime CurrentTime { get; set; }

        public Flight()
        {
        }
    }
}
