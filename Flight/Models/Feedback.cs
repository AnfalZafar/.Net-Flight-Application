using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class Feedback
    {
        public int FId { get; set; }
        public string? FName { get; set; }
        public string? FEmail { get; set; }
        public string? FPhone { get; set; }
        public string? FAddress { get; set; }
        public string? FFeedback { get; set; }
    }
}
