using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class Schedule
    {
        public int SId { get; set; }
        public int? FlightId { get; set; }
        public int? RoutessId { get; set; }
        public int? Departual { get; set; }
        public int? Arraval { get; set; }

        public virtual Flightss? Flight { get; set; }
        public virtual Routess? Routess { get; set; }
    }
}
