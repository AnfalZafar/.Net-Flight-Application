using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class FlightDetail
    {
        public int FlightId { get; set; }
        public string? FlightDetailName { get; set; }
        public string? FlightDescription { get; set; }
        public int? SheduleId { get; set; }
        public int? SpecialId { get; set; }

        public virtual Schedule? Shedule { get; set; }
        public virtual SpecialSet? Special { get; set; }
    }
}
