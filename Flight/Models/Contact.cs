using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string? ContactName { get; set; }
        public string? ContactSubject { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactMessage { get; set; }
    }
}
