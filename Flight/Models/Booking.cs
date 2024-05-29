using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? UsersId { get; set; }
        public int? SheduleId { get; set; }
        public string? NoOfticket { get; set; }
        public string? TotalAmount { get; set; }

        public virtual Schedule? Shedule { get; set; }
    }
}
