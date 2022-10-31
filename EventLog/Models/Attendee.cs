using System;

namespace EventLog.Models
{
    public class Attendee
    {
        public int AttendeeID { get; set; }
        public string? AttendeeName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public decimal Weight { get; set; }
        public string? AttendeeType { get; set; }

    }
}
