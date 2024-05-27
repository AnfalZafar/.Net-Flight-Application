using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class Flightss
    {
        public Flightss()
        {
            Schedules = new HashSet<Schedule>();
            SpecialSets = new HashSet<SpecialSet>();
        }

        public int FId { get; set; }
        public string? FName { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<SpecialSet> SpecialSets { get; set; }
    }
}
