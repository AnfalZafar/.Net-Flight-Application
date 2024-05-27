using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class SpecialSet
    {
        public SpecialSet()
        {
            FlightDetails = new HashSet<FlightDetail>();
        }

        public int SpecialId { get; set; }
        public int? FlightId { get; set; }
        public int? RoutessId { get; set; }
        public DateTime? SDepartual { get; set; }
        public DateTime? SArraval { get; set; }
        public string? SPrice { get; set; }

        public virtual Flightss? Flight { get; set; }
        public virtual Routess? Routess { get; set; }
        public virtual ICollection<FlightDetail> FlightDetails { get; set; }
    }
}
