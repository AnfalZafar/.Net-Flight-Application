using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Bookings = new HashSet<Booking>();
            FlightDetails = new HashSet<FlightDetail>();
        }

        public int SheduleId { get; set; }
        public int? FlightId { get; set; }
        public int? RoutessId { get; set; }
        public DateTime? Departual { get; set; }
        public DateTime? Arraval { get; set; }
        public string? Price { get; set; }

        public virtual Flightss? Flight { get; set; }
        public virtual Routess? Routess { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<FlightDetail> FlightDetails { get; set; }
    }
}
