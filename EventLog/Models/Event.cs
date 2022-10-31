using System;
using System.Collections.Generic;



namespace EventLog.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string? EventName { get; set; } = string.Empty;
        public string? Date { get; set; } = string.Empty;
        public string? Attendees { get; set; } = string.Empty;
        public string? EventType { get; set; } = string.Empty;
        public string? SpecialAttribute { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public IEnumerable<EventType> EventTypeList { get; set; }

        public IEnumerable<SpecialAttribute> SpecialAttributeList { get; set; }

        public IEnumerable<Attendee> AttendeeList { get; set; }
        
    }
}
