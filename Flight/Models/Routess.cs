using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class Routess
    {
        public Routess()
        {
            Schedules = new HashSet<Schedule>();
            SpecialSets = new HashSet<SpecialSet>();
        }

        public int RId { get; set; }
        public string? RFrom { get; set; }
        public string? RTo { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<SpecialSet> SpecialSets { get; set; }
    }
}
