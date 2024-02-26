using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class Routess
    {
        public Routess()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int RId { get; set; }
        public string? RName { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
