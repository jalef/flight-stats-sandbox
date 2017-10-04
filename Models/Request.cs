using System;
using FlightStatsSandbox.Types;

namespace FlightStatsSandbox.Models
{
    public class Request
    {
        public DateTime RequestDateTime { get; set; }
        public RequestTypeEnum RequestType { get; set; } 
        public Airport Airport{ get; set; }
        public int MinutesBefore { get; set; }
        public int MinutesAfter { get; set; }

        public Request()
        {
        }
    }
}
