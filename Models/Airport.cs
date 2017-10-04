using System;
namespace FlightStatsSandbox.Models
{
    public class Airport
    {
		public string IATACode { get; set; }
        public string Name { get; set; }
        public City City { get; set; }

        public Airport()
        {
        }
    }
}
