using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class About
    {
        public int AboutId { get; set; }
        public string? AboutTitle { get; set; }
        public string? AboutName { get; set; }
        public string? AboutDescription { get; set; }
        public string? AboutImg { get; set; }
    }
}
